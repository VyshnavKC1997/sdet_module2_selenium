using BeatXP.ExcelData;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.Utilities
{
    internal class ExcelUtils
    {
        public static List<ExcelPaymentFormData> ReadExcelData(string excelfilepath)
        {
            List<ExcelPaymentFormData> excelDatas = new List<ExcelPaymentFormData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelfilepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables["PaymentForm"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ExcelPaymentFormData excelData = new()
                        {
                            PhoneNumber = row["PhoneNumber"].ToString(),
                            Name = row["Name"].ToString(),
                            Address = row["Address"].ToString(),
                            Pincode = row["Pincode"].ToString(),
                            Email = row["Email"].ToString(),
                            
                        };
                        excelDatas.Add(excelData);
                    }
                }
            }
            return excelDatas;
        }

        public static List<ExcelSearchAndBuyProduct> ReadExcelDataForSearch(string excelfilepath)
        {
            List<ExcelSearchAndBuyProduct> excelDatas = new List<ExcelSearchAndBuyProduct>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelfilepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables["SearchAndBuy"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ExcelSearchAndBuyProduct excelData = new()
                        {
                            SearchData = row["Search"].ToString(),
                            PhoneNumber = row["PhoneNumber"].ToString(),
                            Name = row["Name"].ToString(),
                            Description = row["Description"].ToString(),
                            Title = row["Title"].ToString(),
                            Star= row["Star"].ToString(),

                        };
                        excelDatas.Add(excelData);
                    }
                }
            }
            return excelDatas;
        }
        public static List<ExcelComplaintSearch> ReadExcelDataForSearchFaq(string excelfilepath)
        {
            List<ExcelComplaintSearch> excelDatas = new List<ExcelComplaintSearch>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelfilepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables["SearchFaq"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ExcelComplaintSearch excelData = new()
                        {
                            Search = row["Search"].ToString(),
                           

                        };
                        excelDatas.Add(excelData);
                    }
                }
            }
            return excelDatas;
        }
        public static List<ExcelRaiseAComplaint> ReadExcelDataForRaiseACompaint(string excelfilepath)
        {
            List<ExcelRaiseAComplaint> excelDatas = new List<ExcelRaiseAComplaint>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelfilepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables["RaiseComplaint"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ExcelRaiseAComplaint excelData = new()
                        {
                            Name = row["Name"].ToString(),
                            Email = row["Email"].ToString(),
                            PhoneNumber= row["PhoneNumber"].ToString(),

                        };
                        excelDatas.Add(excelData);
                    }
                }
            }
            return excelDatas;
        }
        public static List<TrackYourOrderExcelData> ReadExcelDataTrackYourOrder(string excelfilepath)
        {
            List<TrackYourOrderExcelData> excelDatas = new List<TrackYourOrderExcelData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelfilepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables["TrackYourOrder"];
                    foreach (DataRow row in dataTable.Rows)
                    {
                        TrackYourOrderExcelData excelData = new()
                        {
                            OrderNumber= row["OrderId"].ToString(),
                            PhoneNumber= row["PhoneNumber"].ToString(),


                        };
                        excelDatas.Add(excelData);
                    }
                }
            }
            return excelDatas;
        }
    }
}
