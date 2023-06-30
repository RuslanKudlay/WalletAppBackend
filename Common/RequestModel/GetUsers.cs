using System;

namespace Common.RequestModel
{
    public class GetUsers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal MaxLimit { get; set; }
        public decimal Available { get; set; }
    }
}
