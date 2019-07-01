using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ExcelDataReader;
using PhantasyApi.Models;

namespace PhantasyApi.Utility
{
    public class Uploader
    {
        public ComboList parseCsvAndMap(string filePath)
        {
            ComboList comboList = new ComboList();
            List<Play> plays = new List<Play>();
            List<Song> songs = new List<Song>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
         
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };

                    var dataSet = reader.AsDataSet(conf);
                    var dataTable = dataSet.Tables[0];

                    DataNamesMapper<Song> mapper = new DataNamesMapper<Song>();
                    DataNamesMapper<Play> playMapper = new DataNamesMapper<Play>();
                    plays = playMapper.Map(dataTable).ToList();
                    songs = mapper.Map(dataTable).ToList();
                  
                }
            }

            comboList.plays = plays;
            comboList.songs = songs;
            

            return comboList;
        }
    }
}
