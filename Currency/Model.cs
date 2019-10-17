using System.Windows.Media;

namespace Currency
{
    class Model
    {
        private string quote, changePercent, num;
        private decimal price, change, previousClose, open, dayLow, dayHigh;
        private System.Windows.Media.Brush color;

        public string Quote { get => quote; set => quote = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal Change { get => change; set => change = value; }
        public string ChangePercent { get => changePercent; set => changePercent = value; }
        public decimal PreviousClose { get => previousClose; set => previousClose = value; }
        public decimal Open { get => open; set => open = value; }
        public decimal DayLow { get => dayLow; set => dayLow = value; }
        public decimal DayHigh { get => dayHigh; set => dayHigh = value; }
        public string Num { get => num; set => num = value; }
        public System.Windows.Media.Brush Color { get => color; set => color = value; }

        public Model ModelClone()
        {
            Model myModel = new Model();

            myModel.quote = this.quote;
            myModel.price = this.price;
            myModel.change = this.change;
            myModel.changePercent = this.changePercent;
            myModel.previousClose = this.previousClose;
            myModel.open = this.open;
            myModel.dayLow = this.dayLow;
            myModel.dayHigh = this.dayHigh;
            myModel.num = this.num;
            myModel.color = this.color;

            return myModel;
        }
    }
}