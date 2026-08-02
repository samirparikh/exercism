#include "perfect_numbers.h"

kind classify_number(int n) {
    if (n < 1) return ERROR;
    int sum = 0;
    for (int i = 1; i < n; i++)
        if (n % i == 0) sum += i;
    if (n == sum) return PERFECT_NUMBER;
    if (n < sum) return ABUNDANT_NUMBER;
    return DEFICIENT_NUMBER;
}
