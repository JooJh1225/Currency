using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Currency
{
    internal class CurrencyViewModel : INotifyPropertyChanged
    {
        private Model model = new Model();

        private ObservableCollection<Model> modelList = new ObservableCollection<Model>();
        public ObservableCollection<Model> ModelList { get => modelList; set => modelList = value; }

        private ObservableCollection<Model> comboboxModelList = new ObservableCollection<Model>();

        public ObservableCollection<Model> ComboBoxModelList { get => comboboxModelList; set => comboboxModelList = value; }

        private bool visibilityBool;

        public bool VisibilityBool
        {
            get { return visibilityBool; }
            set { visibilityBool = value; OnPropertyChanged(nameof(VisibilityBool)); }
        }

        private bool dropDownOpen;

        public bool DropDownOpen
        {
            get { return dropDownOpen; }
            set
            {
                dropDownOpen = value;
                OnPropertyChanged(nameof(DropDownOpen));
            }
        }

        private string selItemQuote;

        public string SelItemQuote
        {
            get { return selItemQuote; }
            set { selItemQuote = value; OnPropertyChanged(nameof(SelItemQuote)); }
        }

        private string selItemPrice;

        public string SelItemPrice
        {
            get { return selItemPrice; }
            set { selItemPrice = value; OnPropertyChanged(nameof(selItemPrice)); }
        }

        private string selItemChange;

        public string SelItemChange
        {
            get { return selItemChange; }
            set { selItemChange = value; OnPropertyChanged(nameof(SelItemChange)); }
        }

        private string selItemChangePercent;

        public string SelItemChangePercent
        {
            get { return selItemChangePercent; }
            set { selItemChangePercent = value; OnPropertyChanged(nameof(SelItemChangePercent)); }
        }

        private string selItemPreviousClose;

        public string SelItemPreviousClose
        {
            get { return selItemPreviousClose; }
            set { selItemPreviousClose = value; OnPropertyChanged(nameof(SelItemPreviousClose)); }
        }

        private string selItemOpen;

        public string SelItemOpen
        {
            get { return selItemOpen; }
            set { selItemOpen = value; OnPropertyChanged(nameof(SelItemOpen)); }
        }

        private string selItemDayLow;

        public string SelItemDayLow
        {
            get { return selItemDayLow; }
            set { selItemDayLow = value; OnPropertyChanged(nameof(SelItemDayLow)); }
        }

        private string selItemDayHigh;

        public string SelItemDayHigh
        {
            get { return selItemDayHigh; }
            set { selItemDayHigh = value; OnPropertyChanged(nameof(SelItemDayHigh)); }
        }

        private System.Windows.Media.Brush tColor;

        public System.Windows.Media.Brush TColor
        {
            get { return tColor; }
            set { tColor = value; OnPropertyChanged(nameof(TColor)); }
        }

        private string selItem;

        public string SelItem
        {
            get { return selItem; }
            set
            {
                int i = 0;
                Regex regex = new Regex(@"(^" + value + @"\b)");
                selItem = value;
                if (selItem != null)
                {
                    foreach (var item in ModelList)
                    {
                        if (regex.IsMatch(ModelList[i].Num))
                        {
                            VisibilityBool = true;
                            TBoxText = ModelList[i].Quote;
                            SelItemQuote = ModelList[i].Quote;
                            SelItemPrice = ModelList[i].Price.ToString();
                            SelItemChange = ModelList[i].Change.ToString();
                            SelItemChangePercent = ModelList[i].ChangePercent;
                            SelItemPreviousClose = ModelList[i].PreviousClose.ToString();
                            SelItemOpen = ModelList[i].Open.ToString();
                            SelItemDayLow = ModelList[i].DayLow.ToString();
                            SelItemDayHigh = ModelList[i].DayHigh.ToString();
                            TColor = ModelList[i].Color;
                        }
                        i++;
                    }
                }
                else
                {
                    VisibilityBool = false;
                    SelItemQuote = null;
                    SelItemPrice = null;
                    SelItemChange = null;
                    SelItemChangePercent = null;
                    SelItemPreviousClose = null;
                    SelItemOpen = null;
                    SelItemDayLow = null;
                    SelItemDayHigh = null;
                }
            }
        }

        private string tBoxText;

        public string TBoxText
        {
            get { return tBoxText; }
            set
            {
                Model model = new Model();

                Regex valueex = new Regex(@"[^가-힣ㄱ-ㅎㅏ-ㅣa-zA-Z]");

                value = valueex.Replace(value, "");

                tBoxText = value;

                Regex combotextex = new Regex(@"(" + value + @")", RegexOptions.IgnoreCase);

                if (tBoxText.Length == 0)
                {
                    dropDownOpen = false;
                    comboboxModelList.Clear();
                    OnPropertyChanged(nameof(tBoxText));
                }
                else if (tBoxText.Length == 1)
                {
                    dropDownOpen = true;
                    comboboxModelList.Clear();
                    int i = 0;
                    foreach (var item in ModelList)
                    {
                        if (combotextex.IsMatch(ModelList[i].Quote))
                        {
                            model.Quote = ModelList[i].Quote;
                            model.Price = ModelList[i].Price;
                            model.Change = ModelList[i].Change;
                            model.ChangePercent = ModelList[i].ChangePercent;
                            model.PreviousClose = ModelList[i].PreviousClose;
                            model.Open = ModelList[i].Open;
                            model.DayLow = ModelList[i].DayLow;
                            model.DayHigh = ModelList[i].DayHigh;
                            model.Num = ModelList[i].Num;
                            model.Color = ModelList[i].Color;

                            comboboxModelList.Add(model.ModelClone());
                        }
                        ++i;
                    }
                }
                else if (tBoxText.Length == 2)
                {
                    dropDownOpen = true;
                    comboboxModelList.Clear();
                    int i = 0;
                    foreach (var item in ModelList)
                    {
                        if (combotextex.IsMatch(ModelList[i].Quote))
                        {
                            model.Quote = ModelList[i].Quote;
                            model.Price = ModelList[i].Price;
                            model.Change = ModelList[i].Change;
                            model.ChangePercent = ModelList[i].ChangePercent;
                            model.PreviousClose = ModelList[i].PreviousClose;
                            model.Open = ModelList[i].Open;
                            model.DayLow = ModelList[i].DayLow;
                            model.DayHigh = ModelList[i].DayHigh;
                            model.Num = ModelList[i].Num;
                            model.Color = ModelList[i].Color;

                            comboboxModelList.Add(model.ModelClone());
                        }
                        ++i;
                    }
                }
                else if (tBoxText.Length == 3)
                {
                    dropDownOpen = true;
                    comboboxModelList.Clear();
                    int i = 0;
                    foreach (var item in ModelList)
                    {
                        if (combotextex.IsMatch(ModelList[i].Quote))
                        {
                            model.Quote = ModelList[i].Quote;
                            model.Price = ModelList[i].Price;
                            model.Change = ModelList[i].Change;
                            model.ChangePercent = ModelList[i].ChangePercent;
                            model.PreviousClose = ModelList[i].PreviousClose;
                            model.Open = ModelList[i].Open;
                            model.DayLow = ModelList[i].DayLow;
                            model.DayHigh = ModelList[i].DayHigh;
                            model.Num = ModelList[i].Num;
                            model.Color = ModelList[i].Color;

                            comboboxModelList.Add(model.ModelClone());
                        }
                        ++i;
                    }
                }
                else if (tBoxText.Length == 4)
                {
                    dropDownOpen = true;
                    comboboxModelList.Clear();
                    int i = 0;
                    foreach (var item in ModelList)
                    {
                        if (combotextex.IsMatch(ModelList[i].Quote))
                        {
                            model.Quote = ModelList[i].Quote;
                            model.Price = ModelList[i].Price;
                            model.Change = ModelList[i].Change;
                            model.ChangePercent = ModelList[i].ChangePercent;
                            model.PreviousClose = ModelList[i].PreviousClose;
                            model.Open = ModelList[i].Open;
                            model.DayLow = ModelList[i].DayLow;
                            model.DayHigh = ModelList[i].DayHigh;
                            model.Num = ModelList[i].Num;
                            model.Color = ModelList[i].Color;

                            comboboxModelList.Add(model.ModelClone());
                        }
                        ++i;
                    }
                }
                else if (tBoxText.Length == 5)
                {
                    dropDownOpen = true;
                    comboboxModelList.Clear();
                    int i = 0;
                    foreach (var item in ModelList)
                    {
                        if (combotextex.IsMatch(ModelList[i].Quote))
                        {
                            model.Quote = ModelList[i].Quote;
                            model.Price = ModelList[i].Price;
                            model.Change = ModelList[i].Change;
                            model.ChangePercent = ModelList[i].ChangePercent;
                            model.PreviousClose = ModelList[i].PreviousClose;
                            model.Open = ModelList[i].Open;
                            model.DayLow = ModelList[i].DayLow;
                            model.DayHigh = ModelList[i].DayHigh;
                            model.Num = ModelList[i].Num;
                            model.Color = ModelList[i].Color;

                            comboboxModelList.Add(model.ModelClone());
                        }
                        ++i;
                    }
                }
                else if (tBoxText.Length == 6)
                {
                    dropDownOpen = true;
                    comboboxModelList.Clear();
                    int i = 0;
                    foreach (var item in ModelList)
                    {
                        if (combotextex.IsMatch(ModelList[i].Quote))
                        {
                            model.Quote = ModelList[i].Quote;
                            model.Price = ModelList[i].Price;
                            model.Change = ModelList[i].Change;
                            model.ChangePercent = ModelList[i].ChangePercent;
                            model.PreviousClose = ModelList[i].PreviousClose;
                            model.Open = ModelList[i].Open;
                            model.DayLow = ModelList[i].DayLow;
                            model.DayHigh = ModelList[i].DayHigh;
                            model.Num = ModelList[i].Num;
                            model.Color = ModelList[i].Color;

                            comboboxModelList.Add(model.ModelClone());
                        }
                        ++i;
                    }
                }
                OnPropertyChanged(nameof(TBoxText));
                OnPropertyChanged(nameof(DropDownOpen));
                OnPropertyChanged(nameof(ComboBoxModelList));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CurrencyViewModel()
        {
            CurrencyUpdate();
        }

        protected void OnPropertyChanged(string propertyName)

        {
            //이벤트를 발생시킨다.
            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CurrencyUpdate()
        {
            int i = 0;
            string url = "https://earthquake.kr:23490";
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(url);
            string responseJson = new StreamReader(stream).ReadToEnd();
            string json = responseJson;
            JObject jar = JObject.Parse(json);
            jar.Remove("update");
            foreach (JToken child in jar.Children())
            {
                ++i;
                var property = child as JProperty;
                if (property != null)
                {
                    var jTokens = property.Value.AsJEnumerable();
                    var js = jTokens.Value<JToken>();
                    model.Quote = property.Name;
                    model.Price = Decimal.Parse(jTokens[0].ToString(), System.Globalization.NumberStyles.Float);
                    model.Change = Decimal.Parse(jTokens[1].ToString(), System.Globalization.NumberStyles.Float);
                    if (Convert.ToString(Decimal.Parse(jTokens[2].ToString(), System.Globalization.NumberStyles.Float)).Length <= 5)
                    {
                        model.ChangePercent = Convert.ToString(Decimal.Parse(jTokens[2].ToString(), System.Globalization.NumberStyles.Float)) + "%";
                    }
                    else
                    {
                        model.ChangePercent = Convert.ToString(Decimal.Parse(jTokens[2].ToString(), System.Globalization.NumberStyles.Float)).Substring(0, 6) + "%";
                    }
                    model.PreviousClose = Decimal.Parse(jTokens[3].ToString(), System.Globalization.NumberStyles.Float);
                    model.Open = Decimal.Parse(jTokens[4].ToString(), System.Globalization.NumberStyles.Float);
                    model.DayLow = Decimal.Parse(jTokens[5].ToString(), System.Globalization.NumberStyles.Float);
                    model.DayHigh = Decimal.Parse(jTokens[6].ToString(), System.Globalization.NumberStyles.Float);
                    if (Decimal.Parse(jTokens[1].ToString(), System.Globalization.NumberStyles.Float) < 0)
                    {
                        model.Color = System.Windows.Media.Brushes.Red;
                    }
                    else if (Decimal.Parse(jTokens[1].ToString(), System.Globalization.NumberStyles.Float) == 0)
                    {
                        model.Color = System.Windows.Media.Brushes.Gray;
                    }
                    else if (Decimal.Parse(jTokens[1].ToString(), System.Globalization.NumberStyles.Float) > 0)
                    {
                        model.Color = System.Windows.Media.Brushes.Green;
                    }
                    model.Num = i.ToString();

                    modelList.Add(model.ModelClone());
                }
                OnPropertyChanged(nameof(ModelList));
            }
        }
    }
}