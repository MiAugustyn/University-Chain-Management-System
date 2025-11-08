using Microsoft.AspNetCore.Html;
using Microsoft.IdentityModel.Tokens;
using System;
using University_Chain_Management_System.Data.Enums;

namespace University_Chain_Management_System.Data
{
    public static class Constants
    {
        // Costant Values

        public static string DefaultUserImage = "https://images.unsplash.com/photo-1628313388777-9b9a751dfc6a?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D";
        public static HtmlString PerformanceShiftNullValue() => new HtmlString($@"
            <div class=""stat-trend trend-stable"">
                <i class=""bi bi-arrow-right-short me-1""></i>
                <span>Not enough valid data.</span>
            </div>");

        // Utility Methods

        public static string GetNotificationContainerClass(NotificationType notificationType) =>
            "notification-icon " + notificationType switch
            {
                NotificationType.Information => " notification-info",
                NotificationType.Warning => " notification-warning",
                NotificationType.Error => " notification-error",
                _ => ""
            };

        public static string GetNotificationIconClass(NotificationType notificationType) =>
            "bi " + notificationType switch
            {
                NotificationType.Information => "bi-info-circle-fill",
                NotificationType.Warning => "bi-exclamation-triangle-fill",
                NotificationType.Error => "bi-x-circle-fill",
                _ => "bi-bell"
            };

        public static string GetGradeColorClass(float grade)
        {
            return grade switch
            {
                > 4 => "bg-success",
                > 3 => "bg-primary",
                > 2 => "bg-warning",
                2 => "bg-danger",
                _ => "bg-secondary",
            };
        }

        public static IHtmlContent DisplayPerformanceShift(int value1, int value2)
        {
            int valueDifference = value1 - value2;

            return DisplayPerformanceShift(valueDifference);
        }

        public static IHtmlContent DisplayPerformanceShiftPercent(float value1, float value2)
        {
            if (Math.Abs(value1 - value2) < 0.01f) { return DisplayPerformanceShift(0, true); }

            float valueDifference = ((value1 - value2) / value2) * 100;
            float rounderNumber = (float)Math.Round(valueDifference, 2);

            return DisplayPerformanceShift(rounderNumber, true);
        }

        public static IHtmlContent DisplayPerformanceShift(float valueDifference, bool inPercent=false)
        {
            var statTrend = "stat-trend " + valueDifference switch
            {
                > 0 => "trend-up",
                < 0 => "trend-down",
                0 => "trend-stable"
            };

            var arrowIcon = "bi " + valueDifference switch
            {
                > 0 => "bi-arrow-up-short",
                < 0 => "bi bi-arrow-down-short",
                0 => "bi-arrow-right-short"
            };

            string valueDifferenceDisplay = $"{valueDifference}{(inPercent ? "%" : "")}";

            var differenceFromPastYear = valueDifference switch
            {
                > 0 =>  $"+{valueDifferenceDisplay} vs ",
                < 0 =>  $"{valueDifferenceDisplay} vs ",
                0 => $"same as "
            } + $"{DateTime.Today.Year - 1}.";

            var html = $@"
            <div class=""{statTrend}"">
                <i class=""{arrowIcon} me-1""></i>
                <span>{differenceFromPastYear}</span>
            </div>";

            return new HtmlString(html);
        }


        public static string GetTimeFromCreation(DateTime date)
        {
            DateTime todayDate = DateTime.Today;

            // Handles future dates as today
            if (todayDate <= date) { return "Today"; }

            int years = todayDate.Year - date.Year;
            int months = todayDate.Month - date.Month;
            int days = todayDate.Day - date.Day;

            if (days < 0)
            {
                DateTime previousMonth = todayDate.AddMonths(-1);
                int daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);

                months -= 1;
                days += daysInPreviousMonth;
            }

            if (months < 0)
            {
                years -= 1;
                months += 12;
            }

            string TimePart(int value, string name) => value > 0 ? $"{value} {name}" + (value > 1 ? "s" : "") : "";

            return $"{TimePart(years, "year")} {TimePart(months, "month")} {TimePart(days, "day")} ago";
        }
    }
}
