namespace Assets.Scripts.SKICombinatorCalculus.Linkedlist
{
    internal class ParserResult
    {
        public ParserResult(StartElement startElement, string calculationProcess)
        {
            this.StartElement = startElement;
            CalculationProcess = calculationProcess;
        }

        public StartElement StartElement { get; protected set; }

        /// <summary>
        /// 計算過程
        /// </summary>
        public string CalculationProcess { get; protected set; }
    }
}
