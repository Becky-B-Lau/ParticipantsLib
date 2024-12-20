using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipantsLib
{
    public class ParticipantRepository
    {
        private int _nextId = 1;
        private List<Participant> _participants = new()
            {
            new Participant(1, "Rene Holten Poulsen", 35, "Denmark"),
            new Participant(2, "Anne-Marie Rindom", 32, "Denmark"),
            new Participant(3, "Armand Duplantis", 24, "Sweden"),
            new Participant(4, "LeBron James", 39, "USA"),
            new Participant(5, "Kevin Durant", 35, "USA")
        };

        public List<Participant> GetAll()
        {
            return new List<Participant>(_participants);
        }

        public Participant GetById(int id)
        {
            return _participants.FirstOrDefault(p => p.Id == id);
        }

        public Participant? Add(Participant participant)
        {
            participant.Validate();
            participant.Id = _nextId++;
            _participants.Add(participant);
            return participant;
        }

        public Participant? Delete(int id)
        {
            var participant = GetById(id);
            if (participant != null)
            {
                _participants.Remove(participant);
            }
            return participant;
        }

    }
}
