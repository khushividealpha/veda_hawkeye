namespace VedaHawkeyeApi.Models
{
    public class BrokerDataFile
    {
        public DateOnly Report_Date { get; set; }
        public string Client_No { get; set; }
        public string Com_Type { get; set; }  
        public string Exch_cd { get; set; }
        public string Com_cd { get; set; }    
        public decimal Strike_Price { get; set; }
        public DateOnly Trade_Date { get; set; }
        public string Buy_Sell { get; set; }  
        public int Traded_Qty { get; set; }
        public decimal Traded_Price { get; set; }
        public string Settle_Curr_Cd { get; set; }    
        public string Order_Id { get; set; }

        /*        public string Trade_Source { get; set; }
                public string Patshub { get; set; }
                public decimal Tick_Value { get; set; }
                public string CQ_Ord_No { get; set; }
                public string LocalUser { get; set; }
                public string User_Id { get; set; }
                public string LocalTraderAC { get; set; }
                public string ExchangeID { get; set; }*/
        /*        public string Call_Put { get; set; } 
                public DateOnly Val_Date { get; set; } */
    }
}
