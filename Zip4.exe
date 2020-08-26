using GoinPostal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip4Natl
{
    class zip4
    {
        private Dictionary<string, int> breaks;//header, length

        public zip4()
        {
            breaks = new Dictionary<string, int>();
            breaks.Add("ZipCode", 5);
            breaks.Add("UpdateKeyNumber", 10);
            breaks.Add("ActionCode", 1);
            breaks.Add("RecordTypeCode", 1);
            breaks.Add("CarrierRouteID", 4);
            breaks.Add("Street Pre Drctn Abb", 2);
            breaks.Add("Street Name", 28);
            breaks.Add("Street Suffix Abb", 4);
            breaks.Add("Street Post Drctn Abb", 2);
            breaks.Add("Addr Primary Low No", 10);
            breaks.Add("Addr Primary High No", 10);
            breaks.Add("Addr Prmry Odd Even Code", 1);
            breaks.Add("Building or Firm Name", 40);
            breaks.Add("Addr Second Abb", 4);
            breaks.Add("Addr Second Low No", 8);
            breaks.Add("Addr Second High No", 8);
            breaks.Add("Addr Secny Odd Even Code", 1);
            breaks.Add("Low Zip Sector No", 2);
            breaks.Add("Low Zip Segment No", 2);
            breaks.Add("High Zip Sector No", 2);
            breaks.Add("High Zip Segment No", 2);
            breaks.Add("Base Alt Code", 1);
            breaks.Add("Lacs Status Ind", 1);
            breaks.Add("Govt Bldg Ind", 1);
            breaks.Add("Finance No", 6);
            breaks.Add("State Abbr", 2);
            breaks.Add("County No", 3);
            breaks.Add("Congressional Dist No", 2);
            breaks.Add("Muncipality Ctyst Key", 6);
            breaks.Add("Urbanization Ctyst Key", 6);
            breaks.Add("Prefd Last Line Ctyst Key", 6);

        }
        public void ConvertToCSV(string inputstring, string outputDestination)
        {
            Int32 vals = inputstring.Length - 182;
            Int32 rowsEst = vals / 182;
            rowsEst = rowsEst / 10;
            Int32 index = 182;
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(new System.IO.FileStream(outputDestination,System.IO.FileMode.CreateNew)))
            {
                string header = "";
                foreach (KeyValuePair<string, int> keyValuePair in breaks)
                {
                    header += keyValuePair.Key + ",";
                }
                header.TrimEnd(new char[] { ',' });
                sw.WriteLine(header);
                int counter = 0;
                int groupsComplete = 0;
                Console.Write("Percent Complete: 0 ");
                while (vals > 0)
                {
                    List<string> r = new List<string>();
                    if ("d".Equals(inputstring.Substring(index, 1).ToLower()))
                    {
                        index += 1;
                        vals -= 1;
                    }
                    else
                    {
                        return;
                    }
                    foreach (KeyValuePair<string, int> keyValuePair in breaks)
                    {
                        if (keyValuePair.Equals("ZipCode"))
                        {
                            r.Add("'" + inputstring.Substring(index, keyValuePair.Value));
                        }
                        else
                        {
                            r.Add(inputstring.Substring(index, keyValuePair.Value));
                        }
                        index += keyValuePair.Value;
                        vals -= keyValuePair.Value;
                    }
                    row rr = new row(r);
                    sw.Write(rr.ToCSV());
                    counter += 1;
                    if (counter % rowsEst == 0)
                    {
                        groupsComplete += 1;
                        Console.Write((groupsComplete * 10) + " ");
                    }
                }
                Console.WriteLine("!");
            }
        }
    }
}
