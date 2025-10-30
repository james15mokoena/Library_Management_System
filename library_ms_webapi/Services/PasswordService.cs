using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace library_ms_webapi.Services
{
    
    /// <summary>
    /// It implements the functionality for hashing a user's password using Argon2 hashing
    /// algorithm. It also includes the functionality for verifying that an existing hashed
    /// password matches with the provided password.
    /// </summary>
    public class PasswordService
    {
        /// <summary>
        /// The salt size is 128 bits.
        /// </summary>
        private const int saltSize = 16;

        /// <summary>
        /// The hash size is 256 bits.
        /// </summary>
        private const int hashSize = 32;

        /// <summary>
        /// The number of threads that can be used in parallel.
        /// </summary>
        private const int degreeOfParallelism = 8;

        /// <summary>
        /// The number of passes or iterations.
        /// </summary>
        private const int numIterations = 4;

        /// <summary>
        /// The memory size that the algorithm will use.
        /// </summary>
        private const int memorySize = 1024 * 1024;

        /// <summary>
        /// Will receive a password and then securely transform it into hash value
        /// using Argon2id algorithm.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GeneratePasswordHash(string password)
        {
            // this is the 16 bytes (128-bit) salt.
            byte[] salt = new byte[saltSize];

            // create a random number generator.
            RandomNumberGenerator generator = RandomNumberGenerator.Create();

            // generate random bytes for the salt.
            generator.GetBytes(salt);

            // release all resources used by the generator.
            generator.Dispose();

            // generate a hash
            byte[] hash = HashPassword(password, salt);

            // combine salt and hash.
            byte[] combinedSaltAndHash = new byte[salt.Length + hash.Length];
            // copy the salt first
            Array.Copy(salt, combinedSaltAndHash, salt.Length);
            // copy the hash last
            Array.Copy(hash, 0, combinedSaltAndHash, salt.Length, hash.Length);

            // convert the result to base64 for storage.
            return Convert.ToBase64String(combinedSaltAndHash);
        }

        /// <summary>
        /// Performs the actual transformation of the password into a 32 bytes hash value,
        /// using Argon2id algorithm.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private static byte[] HashPassword(string password, byte[] salt)
        {
            // will be used to securely transform the password into a hash.
            Argon2id argon2Id = new(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = degreeOfParallelism,
                Iterations = numIterations,
                MemorySize = memorySize
            };

            // this will transform the password into hash value that is 32 bytes long.
            return argon2Id.GetBytes(hashSize);
        }

        /// <summary>
        /// It is responsible for checking if the provided password matches the stored password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        public bool VerifyPassword(string password, string hashedPassword)
        {
            // decode the stored hash
            byte[] combinedSaltAndHash = Convert.FromBase64String(hashedPassword);

            // will store the salt.
            byte[] salt = new byte[saltSize];
            // will store the hash.
            byte[] hash = new byte[hashSize];

            // extract the salt
            Array.Copy(combinedSaltAndHash, 0, salt, 0, salt.Length);
            // extract the hash
            Array.Copy(combinedSaltAndHash, saltSize, hash, 0, hash.Length);

            // compute the hash for the input password.
            byte[] inputPasswordHash = HashPassword(password, salt);
            
            // compare the hashes
            return CryptographicOperations.FixedTimeEquals(hash,inputPasswordHash);
        }
    }
}