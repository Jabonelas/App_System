﻿using System;
using System.Management;

namespace App_TelasCompartilhadas.Classes
{
    public class VerificarComponentesPC
    {
        public string GetDiskSerialNumber()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["SerialNumber"]?.ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Não foi possível extrair o Disk Serial Number");
            }
            return string.Empty;
        }

        public string GetMacAddress()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = true"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["MACAddress"]?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Não foi possível extrair o Mac Address");
            }
            return string.Empty;
        }

        public string GetMotherboardSerialNumber()
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        return obj["SerialNumber"]?.ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Não foi possível extrair o Motherboard Serial Number");
            }
            return string.Empty;
        }
    }
}