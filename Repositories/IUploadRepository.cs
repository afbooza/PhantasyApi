using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhantasyApi.Repositories
{
    public interface IUploadRepository
    {
        Task<int> UploadSongsToDb(string name);
    }
}
