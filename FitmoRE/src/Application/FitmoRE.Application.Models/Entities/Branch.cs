namespace FitmoRE.Application.Models.Entities;

public class Branch
{
    public int BranchId { get; set; }

    public string Address { get; set; }

    public string WorkingHours { get; set; }

    public Branch(int branchId, string address, string workingHours)
    {
        BranchId = branchId;
        Address = address;
        WorkingHours = workingHours;
    }
}
