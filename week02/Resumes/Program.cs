using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Graphic Designer";
        job1._company = "BBM";
        job1._startYear = 2015;
        job1._endYear = 2016;

        Job job2 = new Job();
        job2._jobTitle = "Man";
        job2._company = "Print On";
        job2._startYear = 2022;
        job2._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Saidi Nasibu";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}