using System;
using cgds.manufacture.application.Enums;

namespace cgds.manufacture.application.Entities
{
    public class CalendarProductType : ProductType
    {

        public override string Description => "Calendar";

        public override decimal PackageWidth => 10;

        public override int StackLimit => 1;

        public override EnumProductType Type => EnumProductType.calendar;
    }
}
