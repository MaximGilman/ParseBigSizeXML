using System;
using System.Collections.Generic;
using System.Text;

namespace CountXMLSize
{
    class AddressObject : IXMLParserable
    {
        string AOGUID;
        string FORMALNAME;
        string REGIONCODE;
        string AUTOCODE;
        string AREACODE;
        string CITYCODE;
        string PLACECODE;
        string STREETCODE;
        string OFFNAME;
        string OKATO;
        string OKTMO;
        DateTime UPDATEDATE;
        string   SHORTNAME;
        int      AOLEVEL;
        string   PARENTGUID;
        string   AOID;
        string   PREVID;
        string   NEXTID;
        string   CODE;
        int      ACTSTATUS;
        int      LIVESTATUS;
        int      CENTSTATUS;
        DateTime STARTDATE;
        DateTime ENDDATE;
        public AddressObject() { }

        public override string ToString()
        {
            return ConcatToCSV();
        }

        private string ConcatToCSV(char separator = ',')
        {
            
            return 
                $" {this.AOGUID.AddCommas()}{separator}" +
                $" {this.FORMALNAME.AddCommas()}{separator}" +
                $" {this.REGIONCODE.AddCommas()}{separator}" +
                $" {this.AUTOCODE.AddCommas()}{separator}" +
                $" {this.AREACODE.AddCommas()}{separator}" +
                $" {this.CITYCODE.AddCommas()}{separator}" +
                $" {this.PLACECODE.AddCommas()}{separator}" +
                $" {this.STREETCODE.AddCommas()}{separator}" +
                $" {this.OFFNAME.AddCommas()}{separator}" +
                $" {this.OKATO.AddCommas()}{separator}" +
                $" {this.OKTMO.AddCommas()}"+

                $" {this.UPDATEDATE.ToShortDateString().AddCommas()}{separator}" +
                $" {this.SHORTNAME.AddCommas()}{separator}" +
                $" {this.AOLEVEL.ToString().AddCommas()}{separator}" +
                $" {this.PARENTGUID.AddCommas()}{separator}" +
                $" {this.AOID.AddCommas()}{separator}" +
                $" {this.PREVID.AddCommas()}{separator}" +
                $" {this.NEXTID.AddCommas()}{separator}" +
                $" {this.CODE.AddCommas()}{separator}" +
                $" {this.ACTSTATUS .ToString().AddCommas()}{separator}" +
                $" {this.LIVESTATUS.ToString().AddCommas()}{separator}" +
                $" {this.CENTSTATUS.ToString().AddCommas()}"+
            $" {this.STARTDATE.ToShortDateString().AddCommas()}"+
            $" {this.ENDDATE.ToShortDateString().AddCommas()}";

        }
    }
}
