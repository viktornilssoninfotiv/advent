#include <numeric>
#include <unordered_map>

#include "../util.hpp"

using std::string;
using std::vector;

using child_list = vector<std::pair<int, string>>;
using dict = std::unordered_map<string, child_list>;

dict build_tree(const vector<string>& lines) {
  std::string delimiter = " contain ";
  const std::regex parent_regex("(.+) bag");
  const std::regex child_regex("(\\d+) (.+) bag");

  dict d;

  for (const auto& line : lines) {
    // parse line
    auto n = line.find(delimiter);
    auto s0 = line.substr(0, n);
    auto s1 = line.substr(n + delimiter.size());

    const auto child_strings = util::split(s1, ',');
    child_list children;
    for (const auto& cs : child_strings) {
      auto m1 = util::re_search(child_regex, cs);
      if (m1.size() == 3) {
        children.push_back({std::stoi(m1[1]), m1[2]});
      }
    }

    auto m0 = util::re_search(parent_regex, s0);
    d[m0[1]] = children;
  }

  return d;
}

size_t has_bag_counter = 0;

bool has_bag(const string& container_bag, const string& query_bag,
             const dict& tree_dict) {
  ++has_bag_counter;
  
  if (tree_dict.count(container_bag) == 0) {
    return false;
  }

  const auto children = tree_dict.at(container_bag);

  if (util::contains(children,
                     [&](const auto& c) { return c.second == query_bag; })) {
    return true;
  }

  // recursive call
  for (const auto& c : children) {
    if (has_bag(c.second, query_bag, tree_dict)) {
      return true;
    }
  }

  return false;
}

int count_bags(const string& s, const dict& tree_dict) {
  const auto children = tree_dict.at(s);
  return std::accumulate(children.begin(), children.end(), 0,
                         [&tree_dict](int sum, const auto& child) {
                           const auto& [n, name] = child;
                           return sum + n * (1 + count_bags(name, tree_dict));
                         });
}

int main() {
  auto t0 = cs::high_resolution_clock::now();

  const auto data = util::read_text_file("data.txt");
  const auto lines = util::split(data, '\n');
  const auto tree = build_tree(lines);

  auto t1 = cs::high_resolution_clock::now();

  // part 1
  int count = 0;
  for (const auto& [k, v] : tree) {
    if (has_bag(k, "shiny gold", tree)) {
      ++count;
    }
  }

  std::cout << count << "\n";
  std::cout << "has_bag called " << has_bag_counter << " times\n";
  auto t2 = cs::high_resolution_clock::now();

  // part 2
  std::cout << count_bags("shiny gold", tree) << "\n";

  auto t3 = cs::high_resolution_clock::now();

  std::cout << "execution time of building dict: "
            << cs::duration_cast<cs::milliseconds>(t1 - t0).count() << " ms\n";
  std::cout << "execution time of finding container bags: "
            << cs::duration_cast<cs::milliseconds>(t2 - t1).count() << " ms\n";
  std::cout << "execution time of counting bags: "
            << cs::duration_cast<cs::milliseconds>(t3 - t2).count() << " ms\n";
}