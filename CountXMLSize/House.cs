using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace CountXMLSize
{
    class House
    {
        string POSTALCODE;
        string REGIONCODE;
        string IFNSFL;
        string TERRIFNSFL;
        string IFNSUL;
        string TERRIFNSUL;
        string OKATO;
        string OKTMO;
        DateTime UPDATEDATE;
        string HOUSENUM;
        int ESTSTATUS;
        string BUILDNUM;
        string STRUCNUM;
        int STRSTATUS;
        string HOUSEID;
        string HOUSEGUID;
        string AOGUID;
        DateTime STARTDATE;
        DateTime ENDDATE;
        int STATSTATUS;
        string NORMDOC;
        int COUNTER;
        string CADNUM;
        int DIVTYPE;

        public House() { }
        
        public override string ToString()
        {
            return ConcatToCSV();
        }

        private string ConcatToCSV(char separator = ',')
        {
            /*
              REGIONCODE
              OKATO     
              OKTMO     
              UPDATEDATE
              HOUSENUM  
              ESTSTATUS 
              BUILDNUM  
              STRUCNUM  
              HOUSEID   
              HOUSEGUID 
              AOGUID    
              STARTDATE 
              ENDDATE  
              */
            return $"{this.REGIONCODE.AddCommas()}{separator}" +
                $" {this.OKATO.AddCommas()}{separator}" +
                 $" {this.UPDATEDATE.ToShortDateString().AddCommas()}{separator}" +
                  $" {this.HOUSENUM.AddCommas()}{separator}" +
                   $" {this.ESTSTATUS.ToString().AddCommas()}{separator}" +
                    $" {this.BUILDNUM.AddCommas()}{separator}" +
                    $" {this.STRUCNUM.AddCommas()}{separator}" +
                    $" {this.HOUSEID.AddCommas()}{separator}" +
                    $" {this.HOUSEGUID.AddCommas()}{separator}" +
                    $" {this.AOGUID.AddCommas()}{separator}" +
 $" {this.STARTDATE.ToShortDateString().AddCommas()}{separator}" +
 $" {this.ENDDATE.ToShortDateString().AddCommas()}";



        }
    }
}
