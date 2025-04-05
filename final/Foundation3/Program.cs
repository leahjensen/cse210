using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("153 Wally St", "Seaside", "State", "77353");
        Address address2 = new Address("4124 Spruce Rd", "Townside", "State", "67890");
        Address address3 = new Address("7927 Sand Ave", "Farmside", "State", "11223");

        Event lecture = new Lecture("Tech Talk", "A discussion on new tech trends", new DateTime(2023, 5, 12), "10:00 AM", address1, "Leah Jensen", 50);
        Event wedding = new wedding("Wedding", "A wedding to celebrate love", new DateTime(2023, 6, 15), "7:00 PM", address2, "RSVP at LeahsWedding@gmail.com");
        Event outdoorGathering = new OutdoorGathering("Outdoor Yoga & More", "A relaxing outdoor workout", new DateTime(2023, 7, 20), "8:00 AM", address3, "Sunny and nice");

        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}
