using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Application.Contracts.Profile;

namespace TraficViolation.GB.Application.Abstractions.Profile
{
    public interface IProfileService
    {
        public Task<int> Update(UpdateProfileDto updateProfileDto);
        public string Upload(ProfileImageDto profileImageDto);
        public void Delete(string fileName);
    }
}
