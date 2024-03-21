namespace FitmoRE.Application.Models.Models;

public class BranchModel
{
    public string BranchId { get; set; }

    public string Address { get; set; }

    public string WorkingHours { get; set; }

    public BranchModel(string branchId, string address, string workingHours)
    {
        BranchId = branchId;
        Address = address;
        WorkingHours = workingHours;
    }
}
