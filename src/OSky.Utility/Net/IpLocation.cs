// -----------------------------------------------------------------------
//  <copyright file="IpLocation.cs" company="">
//      Copyright (c) 2014 OSky. All rights reserved.
//  </copyright>
//  <last-editor>Lmf</last-editor>
//  <last-date>2014-10-14 1:26</last-date>
// -----------------------------------------------------------------------

namespace OSky.Utility.Net
{
    /// <summary>
    /// IPλ����Ϣ��
    /// </summary>
    public class IpLocation
    {
        /// <summary>
        /// IP��ַ
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// IP��ַ��������
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// λ����Ϣ
        /// </summary>
        public string Local { get; set; }
    }
}