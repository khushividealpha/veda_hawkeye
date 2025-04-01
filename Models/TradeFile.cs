namespace VedaHawkeyeApi.Models
{
    public class TradeFile
    {
  
        public string? Name { get; set; }  
        public int HeaderIndex { get; set; }
        public string? Type { get; set; }             
        public char? CharacterSplit { get; set; }  
        public int SplitIndex { get; set; } = 0;     
        public string? ConvertValue { get; set; }    
        public string? ConvertOutput { get; set; }    
    }
}
