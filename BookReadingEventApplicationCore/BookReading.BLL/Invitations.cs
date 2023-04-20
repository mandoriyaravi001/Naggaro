using System.Collections.Generic;
using System.Linq;

namespace BLL_Buisness_Logic_Layer_
{
    public class Invitations
    {
        private Invitations objDb;

        public int UserID { get; private set; }
        public int EventId { get; private set; }
        public int UserId { get; private set; }
        public int InvitationActive { get; private set; }

        public Invitations()
        {
            objDb = new Invitations();
        }
        public IEnumerable<Invitations> GetAll()
        {
            return objDb.GetAll();
        }
        public IEnumerable<Invitations> GetById(int id)
        {
            var output = objDb.GetAll().ToList().Where(d => d.UserID == id);
            return output;
        }
        public void Insert(Invitations invitation)
        {
            objDb.Insert(invitation);
        }
        public void Update(Invitations invitation)
        {
            objDb.Update(invitation);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }
        public bool inviteUser(int eventId, int[] userId)
        {

            Invitations invitation = new Invitations();

            for (int i = 0; i < userId.Length; i++)
            {
                invitation.EventId = eventId;
                invitation.UserId = userId[i];
                invitation.InvitationActive = 1;

                objDb.Insert(invitation);
            }
            return true;
        }
    }
}
