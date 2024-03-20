using Signall.Data;

namespace Signall.Services
{
    public interface ISignalService
    {


        Task<ApiResult<Signal>> GetSignal();
        Task<ApiResult<AllorListSignal>> GetListSignal();
        Task<ApiResult<AllorListSignal>> GetAllSignal(string id);

        Task<Response> CreateSignal( string codesignal, string unit, string Value);
        Task<Response> UpdateSignal(string codeupdate, string sequpdate, string unitupdate, string Value);
        Task<Response> DeleteSignal(string codeupdate, string sequpdate);


    }
}
