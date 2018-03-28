using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ClinicController
{
    private List<Pet> pets;
    private List<Clinic> clinics;

    public ClinicController()
    {
        this.pets = new List<Pet>();
        this.clinics = new List<Clinic>();
    }

    public void CreatePet(string[] parts)
    {
        Pet pet = new Pet(parts[0], int.Parse(parts[1]), parts[2]);
        this.pets.Add(pet);
    }

    public void CreateClinic(string[] parts)
    {
        Clinic clinic = new Clinic(parts[0], int.Parse(parts[1]));
        this.clinics.Add(clinic);
    }

    public bool Add(string petName, string clinicName)
    {
        Pet pet = this.pets.FirstOrDefault(p => p.Name == petName);
        Clinic clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

        int roomId = ((int)Math.Ceiling(clinic.Rooms.Length / 2.0)) - 1;
        if (!this.HasEmptyRooms(clinic.Name))
        {
            return false;
        }

        int nextRoom = 1;
        int index = roomId;
        for (int i = 0; i < clinic.Rooms.Length; i++)
        {
            if (clinic.Rooms[index] == null)
            {
                clinic.Rooms[index] = pet;
                return true;
            }
            if (index >= roomId)
            {
                index = roomId - nextRoom;
            }
            else
            {
                index = roomId + nextRoom;
                nextRoom++;
            }
        }
        return false;
    }

    public bool Release(string clinicName)
    {
        Clinic clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
        int roomId = ((int)Math.Ceiling(clinic.Rooms.Length / 2.0)) - 1;
        for (int i = roomId; i < clinic.Rooms.Length; i++)
        {
            if (clinic.Rooms[i] != null)
            {
                clinic.Rooms[i] = null;
                return true;
            }
        }

        for (int i = 0; i < roomId; i++)
        {
            if (clinic.Rooms[i] != null)
            {
                clinic.Rooms[i] = null;
                return true;
            }
        }
        return false;
    }

    public bool HasEmptyRooms(string clinicName)
    {
        Clinic clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
        return clinic.Rooms.Any(r => r == null);
    }

    public void Print(string clinicName)
    {
        Clinic clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
        StringBuilder sb = new StringBuilder();
        foreach (Pet pet in clinic.Rooms)
        {
            if (pet == null)
            {
                sb.AppendLine("Room empty");
            }
            else
            {
                sb.AppendLine(pet.ToString());
            }
        }
        Console.WriteLine(sb.ToString().Trim());
    }

    public void Print(string clinicName, int room)
    {
        Clinic clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
        Pet pet = clinic.Rooms[room - 1];
        if (pet == null)
        {
            Console.WriteLine("Room empty");
        }
        else
        {
            Console.WriteLine(pet);
        }
    }
}