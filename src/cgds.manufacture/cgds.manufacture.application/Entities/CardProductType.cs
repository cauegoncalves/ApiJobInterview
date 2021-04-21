using System;
using cgds.manufacture.application.Enums;

namespace cgds.manufacture.application.Entities
{
    public class CardProductType : ProductType
    {
        public override string Description => "Greeting card";

        public override decimal PackageWidth => 4.7M;

        public override int StackLimit => 1;

        public override EnumProductType Type => EnumProductType.cards;
    }
}
