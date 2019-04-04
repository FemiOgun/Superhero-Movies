using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.SHC.Models;

namespace Web.SHC.Repository
{
    public class CharacterRepository
    {
        static SHCContext context = new SHCContext();
        public static Character Insert(Character character)
        {
            context.Characters.Add(character);
            context.SaveChanges();
            return character;
        }
        public static Character Read(int characterID)
        {
            Character character = null;
            character = context.Characters
                        .Where(a => a.CharacterID == characterID)
                        .FirstOrDefault();
            return character;
        }
        public static void Update(Character character)
        {
            Character chara = new Character();
            chara = context.Characters.Find(character.CharacterID);
            chara.Name = character.Name;
            chara.Abilities = character.Abilities;
            chara.Bio = character.Bio;
            chara.Image = character.Image;
            context.SaveChanges();
        }
        public static void Delete(int characterID)
        {
            Character character = context.Characters.Where(a => a.CharacterID == characterID).FirstOrDefault();
            context.Characters.Remove(character);
            context.SaveChanges();
        }
        public static List<Character> List()
        {
            List<Character> characters =  context.Characters.Include(a => a.Movies).ToList();
            return characters;
        }
    }
}