using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CashRegister.Models.Services;

public sealed class Crc32 : HashAlgorithm
{
    public const uint DefaultPolynomial = 3988292384;
    public const uint DefaultSeed = 4294967295;
    private const int ControlNumberDigits = 4;
    private static uint[] _defaultTable;
    public static readonly int ControlNumberDivisor = (int) Math.Pow(10.0, 4.0);
    private readonly uint _seed;
    private readonly uint[] _table;
    private uint _hash;

    public Crc32()
        : this(3988292384U, uint.MaxValue)
    {
    }

    public Crc32(uint polynomial, uint seed)
    {
        this._table = Crc32.InitializeTable(polynomial);
        this._seed = this._hash = seed;
    }

    public override int HashSize => 32;

    public override void Initialize() => this._hash = this._seed;

    protected override void HashCore(byte[] array, int ibStart, int cbSize) =>
        this._hash = Crc32.CalculateHash(this._table, this._hash, (IList<byte>) array, ibStart, cbSize);

    protected override byte[] HashFinal()
    {
        byte[] bigEndianBytes = Crc32.UInt32ToBigEndianBytes(~this._hash);
        this.HashValue = bigEndianBytes;
        return bigEndianBytes;
    }

    public static uint Compute(byte[] buffer) => Crc32.Compute(uint.MaxValue, buffer);

    public static uint Compute(uint seed, byte[] buffer) => Crc32.Compute(3988292384U, seed, buffer);

    public static uint Compute(uint polynomial, uint seed, byte[] buffer) =>
        ~Crc32.CalculateHash(Crc32.InitializeTable(polynomial), seed, (IList<byte>) buffer, 0, buffer.Length);

    private static uint[] InitializeTable(uint polynomial)
    {
        if (polynomial == 3988292384U && Crc32._defaultTable != null)
            return Crc32._defaultTable;
        uint[] numArray = new uint[256];
        for (int index1 = 0; index1 < 256; ++index1)
        {
            uint num = (uint) index1;
            for (int index2 = 0; index2 < 8; ++index2)
            {
                if (((int) num & 1) == 1)
                    num = num >> 1 ^ polynomial;
                else
                    num >>= 1;
            }

            numArray[index1] = num;
        }

        if (polynomial == 3988292384U)
            Crc32._defaultTable = numArray;
        return numArray;
    }

    private static uint CalculateHash(
        uint[] table,
        uint seed,
        IList<byte> buffer,
        int start,
        int size)
    {
        uint hash = seed;
        for (int index = start; index < size + start; ++index)
            hash = hash >> 8 ^ table[(int) buffer[index] ^ (int) hash & (int) byte.MaxValue];
        return hash;
    }

    private static byte[] UInt32ToBigEndianBytes(uint uint32)
    {
        byte[] bytes = BitConverter.GetBytes(uint32);
        if (BitConverter.IsLittleEndian)
            Array.Reverse((Array) bytes);
        return bytes;
    }

    public static int CalculateControlNumber(
        string OflSeed,
        string DocumentDate,
        string DocumentTime,
        long DocumentNumberLocal,
        long CashRegNumberFiscal,
        long CashRegNumberLocal,
        string DocumentSum,
        string DocumentHash)
    {
        StringBuilder stringBuilder = new StringBuilder(string.Format("{0},{1},{2},{3},{4},{5}", (object) OflSeed,
            (object) DocumentDate, (object) DocumentTime, (object) DocumentNumberLocal, (object) CashRegNumberFiscal,
            (object) CashRegNumberLocal));
        if (!string.IsNullOrWhiteSpace(DocumentSum))
        {
            stringBuilder.Append(",");
            stringBuilder.Append(DocumentSum);
        }

        if (!string.IsNullOrWhiteSpace(DocumentHash))
        {
            stringBuilder.Append(",");
            stringBuilder.Append(DocumentHash);
        }

        byte[] bytes =
            Encoding.ASCII.GetBytes(
                new Regex("\\s+", RegexOptions.Compiled | RegexOptions.Singleline).Replace(stringBuilder.ToString(), ""));
        using Crc32 crc32 = new Crc32();
        crc32.Initialize();
        crc32.ComputeHash(bytes);
        int controlNumber = (int) ((long) BitConverter.ToUInt32(crc32.Hash, 0) % (long) Crc32.ControlNumberDivisor);
        if (controlNumber == 0)
            controlNumber = 1;
        return controlNumber;
    }
}