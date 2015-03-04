using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfraStructure.Entities;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using Phoenix.Infrastructure.Interfaces;
using Microsoft.Practices.Prism.Commands;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;

namespace Recruitment.ViewModel
{
    [Export(typeof(AddCompanyViewModel))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
   public  class AddCompanyViewModel
    {
        private Company _Company=new Company();
        public Company Company { get { return _Company; } set { _Company = value; } }

        private DelegateCommand<Object> saveCompanyCommand;
        public DelegateCommand<Object> SaveCompanyCommand
        {
            get
            {
                saveCompanyCommand = saveCompanyCommand ?? new DelegateCommand<Object>(OnSaveCompanyCommand);
                return saveCompanyCommand;
            }


        }

        private void OnSaveCompanyCommand(Object obj)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.\Sqlexpress1;Initial Catalog = TalentManager;Integrated Security = true";
                con.Open();
                SqlCommand cmd = new SqlCommand("SaveCompany", con);
                cmd.Parameters.Add(new SqlParameter("@Company_Name",Company.Name));
                cmd.Parameters.Add(new SqlParameter("@Address", Company.Address));
                cmd.Parameters.Add(new SqlParameter("@Contact_Person", Company.ContactPerson));
                cmd.Parameters.Add(new SqlParameter("@Phones",CreatePhoneXml()));
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
        }

        private string CreatePhoneXml()
        {
            if ((Company.PhoneNumbers.Select((x) => x.IsEmpty == false)).Count() == 0)
                return String.Empty;
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(stringWriter);
            writer.WriteStartElement("Phones");
            foreach (ITaggableObject obj in Company.PhoneNumbers)
            {
                if (obj.IsEmpty == false)
                {
                    writer.WriteStartElement("Phone");
                    writer.WriteStartElement("Number");
                    writer.WriteValue(((PhoneNumber)obj).Number);
                    writer.WriteEndElement();
                    writer.WriteStartElement("Extension");
                    writer.WriteValue(((PhoneNumber)obj).Extension);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
            return stringWriter.ToString();
        }
    }
}
