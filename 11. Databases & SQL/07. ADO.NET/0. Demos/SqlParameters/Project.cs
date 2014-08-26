using System;

class Project
{
    public Project(int id, string name, string description, DateTime startDate, DateTime? endDate)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.StartDate = startDate;
        this.EndDate = endDate;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public override string ToString()
    {
        string text = String.Format(
            "Project(Id = {0}, \n\tName = {1}, \n\tDescription = {2}, \n\tStartDate = {3}, \n\tEndDate = {4})",
            this.Id, this.Name, this.Description, this.StartDate, this.EndDate);
        return text;
    }
}
