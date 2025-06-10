namespace Core.Concretes.DTOs.DirectMessage
{
    public class DirectMessageDTO
    {
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; }
        public required Guid SenderId { get; set; }
        public string? SenderUserName { get; set; }
        public string? SenderProfilePictureUrl { get; set; }
        public required Guid ReceiverId { get; set; }
        public string? ReceiverUserName { get; set; }
        public string? ReceiverProfilePictureUrl { get; set; }
        public bool IsRead { get; set; }
    }
}
