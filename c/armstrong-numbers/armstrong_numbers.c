#include "armstrong_numbers.h"
#include <math.h>

int number_of_digits(unsigned int number) {
    if (number == 0) return 1;
    else return floor(log10(number) + 1);
}

bool is_armstrong_number(int candidate) {
    int sum = 0;
    int no_digits = number_of_digits(candidate);
    int n = candidate;

    do {
        sum += pow(n % 10, no_digits);
        n /= 10;
    } while (n != 0);
    return (sum == candidate);
}
