using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommunityService" in both code and config file together.
[ServiceContract]
public interface ICommunityService
{
    [OperationContract]
    int Login(string email, string password);

    [OperationContract]
    int RegisterUser(personInfo p);

    [OperationContract]

    List<GrantRequest> ReviewGrant(int pKey);

    [OperationContract]

    List<GrantReviewComment> viewGrants (string listofgrants);

    [OperationContract]

    bool newGrant(GrantRequest g);
}

[DataContract]

public class ApplyGrant
{
    [DataMember]
    public List<GrantRequest> apply {get; set;}
}

public class viewGrant
{
    [DataMember]
    public List<GrantReviewComment> type { get; set; }
}

public class personInfo
{
    [DataMember]
    public string lastName { get; set; }

    [DataMember]
    public string fisrtName { get; set; }

    [DataMember]
    public string email { get; set; }

    [DataMember]
    public string password { get; set; }

    [DataMember]
    public string apartmentNumber { get; set; }

    [DataMember]
    public string street { get; set; }

    [DataMember]
    public string city { get; set; }

    [DataMember]
    public string state { get; set; }

    [DataMember]
    public string zipCode { get; set; }

    [DataMember]
    public string homePhone { get; set; }

    [DataMember]
    public string workPhone { get; set; }
}
