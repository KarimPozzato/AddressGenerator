using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_AddressGenerator
{
    interface IAddress
    {
        string generateIPv4();
        string generateSubnet();
    }

    internal class AddressGenerator : IAddress
    {
        private uint bits; //int, la variabile uint inizia a contenere da 0

        public AddressGenerator(uint bits)
        {
            this.bits = bits;
        }

        public string generateIPv4()
        {
            byte[] bytes = BitConverter.GetBytes(bits);

            if (BitConverter.IsLittleEndian)
            { 
                Array.Reverse(bytes); 
                // se il sistema è little-endian, invertiamo l'ordine dei byte
                //Little-endian è un'organizzazione di byte in cui i byte meno significativi vengono memorizzati all'inizio della parola di memoria.
                //bisogna invertire l'ordine dei byte per accedere correttamente ai singoli byte che compongono il valore.
            }

            return new IPAddress(bytes).ToString();
        }

        public string generateSubnet()
        {
            byte[] subnetMask = BitConverter.GetBytes(~(bits - 1));

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(subnetMask);
            }

            return new IPAddress(subnetMask).ToString();
        }
    }
}

/*interface IAddress
{
    string generateIPv4();
    string generateSubnet();
}

class AddressGenerator : IAddress
{
    private uint ipAddress;

    public AddressGenerator(uint ipAddress)
    {
        this.ipAddress = ipAddress;
    }

    public string generateIPv4()
    {
        return new IPAddress(ipAddress).ToString();
    }

    public string generateSubnet()
    {
        return "255.255.255.0";
    }
}*/
