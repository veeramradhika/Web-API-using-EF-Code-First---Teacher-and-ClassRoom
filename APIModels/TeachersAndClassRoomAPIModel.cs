namespace WebApiProjectEFDb.APIModels
{
    public class TeachersAndClassRoomAPIModel
    {
        public TeachersAPIModel Teacher { get; set; }

        public List<ClassRoomAPIModel> classRoomList { get; set; }
    }
}
