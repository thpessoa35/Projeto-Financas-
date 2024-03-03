using credit;
using iCreditRepository;

namespace getAllCreditUseCase
{
    public class GetAllCreditUseCase
    {
        private ICreditRepository _IcreditRepository;

        public GetAllCreditUseCase(ICreditRepository creditRepository)
        {
            _IcreditRepository = creditRepository;
        }

        public async Task<List<Credit>> FindALL(string iduser)
        {
            try
            {

                var all = await _IcreditRepository.FindAll(iduser);

                return all.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
