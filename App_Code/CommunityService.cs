using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommunityService" in code, svc and config file together.
public class CommunityService : ICommunityService
{
    Community_AssistEntities db = new Community_AssistEntities();

    



    public int Login(string email, string password)
    {
        {
            int key = 0;
            int result = db.usp_Login(email, password);

            //Community_AssistEntities db = new Community_AssistEntities();
            //int success = db.usp_Login(email, password);

            if (result != -1)
            {
                var uKey = (from k in db.People
                            where k.PersonEmail.Equals(email)
                            select k.PersonKey).FirstOrDefault();

                key = (int)uKey;
                

            }

            return key;

        }
    }

    public bool newGrant(GrantRequest g)
    {
        db.GrantRequests.Add(g);
        db.SaveChanges();
        return true;
    }

    public int RegisterUser(personInfo p)
    {

        var perinfo = from b in db.People

                      select b;
        List<Person> person = new List <Person>();
        // List<personInfo> per = new List<personInfo>();
        //bool result = true;
        int result = db.usp_Register(p.lastName, p.fisrtName, p.email, p.password, p.apartmentNumber, p.street, p.city, p.state, p.zipCode, p.homePhone, p.workPhone);


        return result;

    }

    public List<GrantRequest> ReviewGrant (int personKey)
    {
        var rev = from b in db.GrantRequests  where b.PersonKey==personKey select b;
        List<GrantRequest> grat = new List<GrantRequest>();

        foreach(var r in rev)
        {
            GrantRequest gr = new GrantRequest();
            gr.GrantRequestAmount = r.GrantRequestAmount;
            gr.GrantRequestDate = r.GrantRequestDate;
            gr.GrantRequestExplanation = r.GrantRequestExplanation;
            gr.PersonKey = r.PersonKey;

            grat.Add(gr); 

        }
        return grat;
    }


    public List<GrantReviewComment> viewGrants(string listofgrants)
    {
        throw new NotImplementedException();
    }
}
