namespace PrimeService
{
    public class PrimeService
    {
        /// <summary>
        /// Determines if a number is prime using optimized trial division
        /// Time complexity: O(√n)
        /// </summary>
        public bool IsPrime(int candidate)
        {
            if (candidate < 2)
                return false;

            if (candidate == 2 || candidate == 3)
                return true;

            if (candidate % 2 == 0 || candidate % 3 == 0)
                return false;

            for (int i = 3; i <= candidate; i += 6)
            {
                if (candidate % i == 0 || candidate % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Finds all prime numbers up to a given limit using Sieve of Eratosthenes
        /// Time complexity: O(n log log n)
        /// </summary>
        public int[] FindPrimesUpTo(int limit)
        {
            if (limit < 2)
                return new int[0];

            bool[] isPrime = new bool[limit + 1];
            for (int i = 2; i <= limit; i++)
                isPrime[i] = true;

            for (int i = 2; i * i <= limit; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                        isPrime[j] = false;
                }
            }

            var primes = new List<int>();
            for (int i = 2; i <= limit; i++)
            {
                if (isPrime[i])
                    primes.Add(i);
            }

            return primes.ToArray();
        }

        /// <summary>
        /// Gets the next prime number after the given number
        /// Uses the optimized IsPrime method for checking
        /// </summary>
        /// 

        public int GetNextPrime(int number)
        {
            if (number < 2) return 2;

            int candidate = number + 1;

            while (true)
            {
                if (IsPrime(candidate)) return candidate;

                try
                {
                    candidate = checked(candidate + 1); // Overflow protection
                }
                catch (OverflowException)
                {
                    throw new InvalidOperationException("No prime found within integer range.");
                }
            }
        }
    }
}