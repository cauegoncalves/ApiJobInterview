using System;
using cgds.manufacture.application.Enums;

namespace cgds.manufacture.application.Entities
{
    public class CanvasProductType : ProductType
    {

        public override string Description => "Canvas";

        public override decimal PackageWidth => 16;

        public override int StackLimit => 1;

        public override EnumProductType Type => EnumProductType.canvas;
    }
}
