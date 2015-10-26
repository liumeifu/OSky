using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSky.Core.Data;
using OSky.UI.Contracts;
using OSky.UI.Models.Identity;


namespace OSky.UI.Services
{
    public class TestService : ITestContract
    {
        /// <summary>
        /// 获取或设置 用户仓储对象
        /// </summary>
        public IRepository<User, int> UserRepository { get; set; }

        #region Implementation of ITestContract

        public void Test()
        {
            int count = UserRepository.UpdateDirect(m => true, user => new User() { NickName = "柳柳英侠112" });

        }

        #endregion
    }
}
