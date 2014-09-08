namespace Cars.XML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Data.Contracts;
    using Models;
    using Models.Projections;

    public class QueryXmlParser
    {
        private readonly ICarsContext carsContext;

        public QueryXmlParser(ICarsContext carsContext)
        {
            this.carsContext = carsContext;
        }


        public void GetResults(string xmlFilePath, string queriesResultExportXmlFilePath)
        {
            var queriesXml = XElement.Load(xmlFilePath).Elements("Query");

            foreach (var queryXml in queriesXml)
            {
                var resultSet = this.carsContext.Cars.AsQueryable();
                var outPutFileName = queryXml.Attribute("OutputFileName").Value;

                if (queryXml.Element("OrderBy") != null)
                {
                    resultSet = this.OrderBy(resultSet, queryXml.Element("OrderBy"));
                }

                var whereXml = queryXml.Elements("WhereClauses");
                foreach (var whereClauseElement in whereXml.Elements("WhereClause"))
                {
                    var propertyName = whereClauseElement.Attribute("PropertyName").Value;
                    var type = whereClauseElement.Attribute("Type").Value;
                    var value = whereClauseElement.Value;

                    resultSet = this.GetWhereQuery(resultSet, propertyName, type, value);
                }

                List<SearchResultProjection> searchResult = resultSet.Select(c => new SearchResultProjection
                {
                    Model = c.Model,
                    ManufacturerName = c.Manufacturer.Name,
                    Year = c.Year,
                    Price = c.Price,
                    TransmissionType = c.TransmissionType,
                    DealerName = c.Dealer.Name,
                    Cities = c.Dealer.Cities.Select(city => city.Name),

                }).ToList();

                this.CreateResultFile(searchResult, outPutFileName, queriesResultExportXmlFilePath);
                
            }
        }

        private void CreateResultFile(List<SearchResultProjection> searchResult, string outPutFileName, string queriesResultExportXmlFilePath)
        {
           
            var searchResultXml = new XElement("Cars");
            /*XNamespace ns = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace otherNs = "http://www.w3.org/2001/XMLSchema";

            searchResultXml.SetAttributeValue("xmlns:xsi", ns);
            searchResultXml.SetAttributeValue("xmlns:xsd", otherNs);*/

            //TODO: here!!!
            foreach (var carProjection in searchResult)
            {
                var carSet = new XElement("Car");
                carSet.SetAttributeValue("Manufacturer", carProjection.ManufacturerName);
                carSet.SetAttributeValue("Model", carProjection.Model);
                carSet.SetAttributeValue("Year", carProjection.Year);
                carSet.SetAttributeValue("Price", carProjection.Price);

                string nameOfTranType = carProjection.TransmissionType.ToString();
                var transmissionType = new XElement("TransmissionType") { Value = nameOfTranType.ToLower() };

                var dealerXml = new XElement("Dealer");
                dealerXml.SetAttributeValue("Name", carProjection.DealerName);

                var citiesXml = new XElement("Cities");

                foreach (var city in carProjection.Cities)
                {
                    var cityXml = new XElement("City", city);
                    citiesXml.Add(cityXml);
                }


                dealerXml.Add(citiesXml);
                carSet.Add(transmissionType, dealerXml);
                searchResultXml.Add(carSet);
            }

            searchResultXml.Save(new StreamWriter(queriesResultExportXmlFilePath + outPutFileName, false));
            Console.WriteLine("\nResult Query Created at: {0}", queriesResultExportXmlFilePath + outPutFileName);
        }

        private IQueryable<Car> GetWhereQuery(IQueryable<Car> resultSet, string propertyName, string type, string value)
        {
            if (type == "Equals")
            {
                if (propertyName == "Id")
                {
                    var valueId = int.Parse(value);
                    resultSet = resultSet.Where(c => c.Id == valueId);
                }

                if (propertyName == "Year")
                {
                    var yearValue = int.Parse(value);
                    resultSet = resultSet.Where(c => c.Year == yearValue);
                }

                if (propertyName == "Price")
                {
                    var priceValue = decimal.Parse(value);
                    resultSet = resultSet.Where(c => c.Price == priceValue);
                }
                if (propertyName == "Model")
                {
                    resultSet = resultSet.Where(c => c.Model == value);
                }
                if (propertyName == "Manufacturer")
                {
                    resultSet = resultSet.Where(c => c.Manufacturer.Name == value);
                }
                if (propertyName == "Dealer")
                {
                    resultSet = resultSet.Where(c => c.Dealer.Name == value);
                }
                if (propertyName == "City")
                {
                    resultSet = resultSet.Where(c => c.Dealer.Cities.Any(city => city.Name == value));
                }
            }
            else if (type == "GreaterThan")
            {
                if (propertyName == "Id")
                {
                    var valueId = int.Parse(value);
                    resultSet = resultSet.Where(c => c.Id > valueId);
                }

                if (propertyName == "Year")
                {
                    var yearValue = int.Parse(value);
                    resultSet = resultSet.Where(c => c.Year > yearValue);
                }
                if (propertyName == "Price")
                {
                    var priceValue = decimal.Parse(value);
                    resultSet = resultSet.Where(c => c.Price > priceValue);
                }
            }
            else if (type == "LessThan")
            {
                if (propertyName == "Id")
                {
                    var valueId = int.Parse(value);
                    resultSet = resultSet.Where(c => c.Id < valueId);
                }

                if (propertyName == "Year")
                {
                    var yearValue = int.Parse(value);
                    resultSet = resultSet.Where(c => c.Year < yearValue);
                }
                if (propertyName == "Price")
                {
                    var priceValue = decimal.Parse(value);
                    resultSet = resultSet.Where(c => c.Price < priceValue);
                }
            }
            else if (type == "Contains")
            {
                if (propertyName == "Model")
                {
                    resultSet = resultSet.Where(c => c.Model.Contains(value));
                }
                if (propertyName == "Manufacturer")
                {
                    resultSet = resultSet.Where(c => c.Manufacturer.Name.Contains(value));
                }
                if (propertyName == "Dealer")
                {
                    resultSet = resultSet.Where(c => c.Dealer.Name.Contains(value));
                }
            }

            return resultSet;
        }

        private IQueryable<Car> OrderBy(IQueryable<Car> resultSet, XElement orderElement)
        {
            string value = orderElement.Value;

            if (value == "Id")
            {
                resultSet = resultSet.OrderBy(c => c.Id);
            }
            else if (value == "Year")
            {
                resultSet = resultSet.OrderBy(c => c.Year);
            }
            else if (value == "Model")
            {
                resultSet = resultSet.OrderBy(c => c.Model);
            }
            else if (value == "Price")
            {
                resultSet = resultSet.OrderBy(c => c.Price);
            }
            else if (value == "Manufacturer ")
            {
                resultSet = resultSet.OrderBy(c => c.Manufacturer.Name);
            }
            else if (value == "Dealer ")
            {
                resultSet = resultSet.OrderBy(c => c.Dealer.Name);
            }

            return resultSet;
        }
    }
}

/*
 <?xml version="1.0"?>
<Queries xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Query OutputFileName="Result0.xml">
    <OrderBy>Id</OrderBy>
    <WhereClauses>
      <WhereClause PropertyName="City" Type="Equals">Sofia</WhereClause>
      <WhereClause PropertyName="Year" Type="GreaterThan">1999</WhereClause>
    </WhereClauses>
  </Query>
</Queries>
*/