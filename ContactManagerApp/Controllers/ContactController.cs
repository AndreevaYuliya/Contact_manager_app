using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactManagerApp;
using ContactManagerApp.Models;
using CsvHelper;
using CsvHelper.Configuration;

public class ContactController : Controller
{
    private ContactDbContext db = new ContactDbContext();

    // GET: Contacts
    public ActionResult Index()
    {
        var contacts = db.Contacts.ToList();

        // Ensure phone numbers are formatted in the desired way
        foreach (var contact in contacts)
        {
            // Assuming contact.Phone is a string or numeric, format it
            if (!string.IsNullOrEmpty(contact.Phone))
            {
                // If the phone is numeric, ensure it is in string format
                contact.Phone = contact.Phone.PadLeft(12, '0'); // Add leading zeros if needed
                contact.Phone = string.Format("{0:(###)-####-####}", contact.Phone); // Format to the desired pattern
            }
        }

        return View(contacts);
    }


    // POST: Upload CSV
    [HttpPost]
    public ActionResult UploadCSV(HttpPostedFileBase file)
    {
        if (file != null && file.ContentType == "text/csv")
        {
            using (var reader = new StreamReader(file.InputStream))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",  // Use semicolon as the delimiter
                    HeaderValidated = null,  // Disable header validation
                    MissingFieldFound = null  // Ignore missing fields
                };

                var csv = new CsvReader(reader, csvConfig);
                csv.Context.RegisterClassMap<ContactMap>();  // Register the custom ClassMap

                // Read the records and automatically convert "Yes"/"No" to true/false
                var records = csv.GetRecords<Contact>()
                    .Select(record =>
                    {
                        record.Id = 0;  // Ignore Id, let the database auto-generate it
                        return record;
                    })
                    .ToList();

                foreach (var record in records)
                {
                    db.Contacts.Add(record);  // Add each record to the database
                }

                db.SaveChanges();  // Save changes to the database
            }

            return RedirectToAction("Index");  // Redirect back to the Index view
        }

        return View();  // Return to the view if no file was uploaded
    }



    // POST: Update Contact
    [HttpPost]
    public ActionResult UpdateContact(Contact contact)
    {
        if (ModelState.IsValid)
        {
            var existingContact = db.Contacts.Find(contact.Id);
            if (existingContact != null)
            {
                existingContact.Name = contact.Name;
                existingContact.DateOfBirth = contact.DateOfBirth;
                existingContact.Married = contact.Married;
                existingContact.Phone = contact.Phone;
                existingContact.Salary = contact.Salary;
                db.SaveChanges();
            }
        }
        return Json(new { success = true });
    }

    // POST: Delete Contact
    [HttpPost]
    public ActionResult DeleteContact(int id)
    {
        var contact = db.Contacts.Find(id);
        if (contact != null)
        {
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }
        return Json(new { success = true });
    }
}
