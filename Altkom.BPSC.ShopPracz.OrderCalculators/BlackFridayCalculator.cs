using Altkom.BPSC.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.BPSC.ShopPracz.OrderCalculators
{

    public interface ICalculator
    {
        void Calculate(Order order);
    }

    public class BlackFridayCalculator : ICalculator
    {
        public void Calculate(Order order)
        {
            if (order.OrderDate.DayOfWeek == DayOfWeek.Friday)
            {
                order.DiscountAmount = order.TotalAmount * 0.3m;
            }
            else
            {
                order.DiscountAmount = 0;
            }
        }
    }

    public class HappyHoursCalculator : ICalculator
    {
        public void Calculate(Order order)
        {
            // Thread.Sleep(TimeSpan.FromSeconds(1));

            if (order.OrderDate.TimeOfDay > TimeSpan.FromHours(11.5)
                && order.OrderDate.TimeOfDay < TimeSpan.FromHours(13)
                )
            {
                order.DiscountAmount = order.TotalAmount - 10m;
            }
            else
            {
                order.DiscountAmount = 0;
            }
        }
    }


   

    public class HappyDayOfWeekStrategy : IStrategy
    {
        private readonly DayOfWeek happyDayOfWeek;
        private readonly decimal percentage;

        public HappyDayOfWeekStrategy(DayOfWeek happyDayOfWeek, 
            decimal percentage)
        {
            this.happyDayOfWeek = happyDayOfWeek;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.DayOfWeek == happyDayOfWeek;
        }

        public decimal GetDiscount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }


    public class HappyHourStrategy : IStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        private readonly decimal fixedDiscount;

        public HappyHourStrategy(TimeSpan from, TimeSpan to, decimal fixedPrice)
        {
            this.from = from;
            this.to = to;
            this.fixedDiscount = fixedPrice;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from
                && order.OrderDate.TimeOfDay <= to;
        }

        public decimal GetDiscount(Order order)
        {
            return fixedDiscount;
        }
    }

    public class HappyHoursPercentageStrategy : IStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        private readonly decimal percentage;

        public HappyHoursPercentageStrategy(TimeSpan from, TimeSpan to, decimal percentage)
        {
            this.from = from;
            this.to = to;
            this.percentage = percentage;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from
                && order.OrderDate.TimeOfDay <= to;
        }

        public decimal GetDiscount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }

    public class OrderCalculator
    {
        private readonly IStrategy strategy;

        public OrderCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Calculate(Order order)
        {
            if (strategy.CanDiscount(order))
            {
                order.DiscountAmount = strategy.GetDiscount(order);
            }
            else
            {
                order.DiscountAmount = 0;
            }
        }
    }

    public interface IStrategy
    {
        bool CanDiscount(Order order);
        decimal GetDiscount(Order order);
    }

    public interface IRuleStrategy
    {
        bool CanDiscount(Order order);
    }

    public interface IDiscountStrategy
    {
        decimal GetDiscount(Order order);
    }

    public class HappyHoursRuleStrategy : IRuleStrategy
    {
        private readonly TimeSpan from;
        private readonly TimeSpan to;

        public HappyHoursRuleStrategy(TimeSpan from, TimeSpan to)
        {
            this.from = from;
            this.to = to;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.TimeOfDay >= from
                && order.OrderDate.TimeOfDay <= to;
        }
    }

    public interface IRuleStrategy<T>
    {
        bool CanDiscount(T item);
    }

    public class DelegateRuleStrategy<T> : IRuleStrategy<T>
    {
        private readonly Predicate<T> predicate;

        public DelegateRuleStrategy(Predicate<T> predicate)
        {
            this.predicate = predicate;
        }

        public bool CanDiscount(T item) => predicate(item);
    }

    public class HappyDayRuleStrategy : IRuleStrategy
    {
        private readonly DayOfWeek dayOfWeek;

        public HappyDayRuleStrategy(DayOfWeek dayOfWeek) 
            => this.dayOfWeek = dayOfWeek;

        public bool CanDiscount(Order order)
            => order.OrderDate.DayOfWeek == dayOfWeek;
    }

    public class PercentageDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal percentage;

        public PercentageDiscountStrategy(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal GetDiscount(Order order)
        {
            return order.TotalAmount * percentage;
        }
    }

    public class FixedAmountDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal fixedAmount;

        public FixedAmountDiscountStrategy(decimal fixedAmount)
            => this.fixedAmount = fixedAmount;

        public decimal GetDiscount(Order order) => fixedAmount;
    }

    public class OrderDiscountCalculator
    {
        private readonly IRuleStrategy ruleStrategy;
        private readonly IDiscountStrategy discountStrategy;

        public OrderDiscountCalculator(
            IRuleStrategy ruleStrategy,
            IDiscountStrategy discountStrategy
            )
        {
            this.ruleStrategy = ruleStrategy;
            this.discountStrategy = discountStrategy;
        }

        public void Calculate(Order order)
        {
            if (ruleStrategy.CanDiscount(order))
            {
                order.DiscountAmount = discountStrategy.GetDiscount(order);
            }
            else
            {
                order.DiscountAmount = 0;
            }
        }
    }
}
