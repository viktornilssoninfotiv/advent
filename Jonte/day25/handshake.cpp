
#include <algorithm>
#include <chrono>
#include <iostream>
#include <vector>

namespace cs = std::chrono;

constexpr int subject_number = 7;
constexpr int denominator = 20201227;

int compute_key(size_t loop_size) {
  int val = 1;

  for (size_t i = 0; i < loop_size; ++i) {
    val *= subject_number;
    val = val % denominator;
  }

  return val;
}

int get_next(int val) {
  int next_val = val * subject_number;
  return next_val % denominator;
}

int main() {
  size_t max_size = 1e8;

  std::vector<int> values(max_size);

  auto t0 = cs::high_resolution_clock::now();

  values[0] = 1;
  for (size_t i = 1; i < max_size; ++i) {
    values[i] = get_next(values[i - 1]);
  }

  auto t1 = cs::high_resolution_clock::now();

  std::cout << "computed values for " << max_size << " loop sizes in "
            << cs::duration_cast<cs::milliseconds>(t1 - t0).count() << " ms\n";            

  int card_public_key = 2959251;
  int door_public_key = 4542595;

  auto it_card = std::find(values.begin(), values.end(), card_public_key);
  if (it_card != values.end()) {
    std::cout << "card loop size: " << std::distance(values.begin(), it_card)
              << "\n";
  } else {
    std::cout << "unable to find card loop size\n";
  }

  auto it_door = std::find(values.begin(), values.end(), door_public_key);
  if (it_door != values.end()) {
    std::cout << "door loop size: " << std::distance(values.begin(), it_door)
              << "\n";
  } else {
    std::cout << "unable to find door loop size\n";
  }
}
