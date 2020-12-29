
// compile with g++ -std=c++17 -O3 crab_cups.cpp

#include <chrono>
#include <iostream>
#include <vector>

namespace cs = std::chrono;

struct node {
  int val;
  node* prev{nullptr};
  node* next{nullptr};
};

node* advance(node* start_node, size_t steps) {
  node* node = start_node;
  for (size_t i = 0; i < steps; ++i) {
    node = node->next;
  }
  return node;
}

void connect(node* n1, node* n2) {
  n1->next = n2;
  n2->prev = n1;
}

std::vector<node> init_circular_nodes(size_t size) {
  // pad with unused nodes to allow simple indexing by value
  std::vector<node> nodes(size + 2);

  for (size_t i = 1; i < size + 1; ++i) {
    nodes[i].val = i;
    connect(&nodes[i], &nodes[i + 1]);
  }
  connect(&nodes[size], &nodes[1]);

  return nodes;
}

int get_destination_label(int val, int* pick_up, size_t size) {
  val = val != 0 ? val : size;

  if (val == pick_up[0] || val == pick_up[1] || val == pick_up[2]) {
    return get_destination_label(val - 1, pick_up, size);
  } else {
    return val;
  }
}

void simulate_crab_moves(std::vector<node>& nodes, node* start_node,
                         size_t size, size_t n_moves) {
  node* curr_node = start_node;

  for (size_t i = 0; i < n_moves; ++i) {
    int curr_label = curr_node->val;

    // pick up cups
    node* pick_up_first = curr_node->next;
    node* pick_up_last = advance(curr_node, 3);

    // detach picked-up cups from list
    connect(curr_node, pick_up_last->next);

    int pick_up_labels[] = {pick_up_first->val, pick_up_first->next->val,
                            pick_up_last->val};

    int destination_label =
        get_destination_label(curr_label - 1, pick_up_labels, size);
    node* destination_node = &nodes[destination_label];

    // re-attach picked-up cups after destination cup
    node* old_next = destination_node->next;

    connect(destination_node, pick_up_first);
    connect(pick_up_last, old_next);

    // finally, advance current node for next iteration
    curr_node = curr_node->next;
  }
}

void print_nodes(node* start, size_t size) {
  node* curr = start;

  for (size_t i = 0; i < size; ++i) {
    std::cout << curr->val << " ";
    curr = curr->next;
  }
  std::cout << "\n";
}

int main() {
  /* ---------- part 1 ---------- */
  //   int input[] = {3, 8, 9, 1, 2, 5, 4, 6, 7};
  int input[] = {4, 6, 9, 2, 1, 7, 5, 3, 8};
  size_t size = 9;

  // setup input
  auto nodes = init_circular_nodes(size);

  for (size_t i = 0; i < size - 1; ++i) {
    int l = input[i];
    int r = input[i + 1];
    connect(&nodes[l], &nodes[r]);
  }
  connect(&nodes[input[size - 1]], &nodes[input[0]]);
  
  // simulate
  node* start = &nodes[input[0]];
  simulate_crab_moves(nodes, start, size, 100);
  print_nodes(nodes[1].next, size - 1);

  /* ---------- part 2 ---------- */
  size_t big_size = 1e6;
  auto big_nodes = init_circular_nodes(big_size);

  for (size_t i = 0; i < size - 1; ++i) {
    int l = input[i];
    int r = input[i + 1];
    connect(&big_nodes[l], &big_nodes[r]);
  }
  connect(&big_nodes[input[size - 1]], &big_nodes[size + 1]);
  connect(&big_nodes[big_size], &big_nodes[input[0]]);

  // simulate
  auto t0 = cs::high_resolution_clock::now();
  simulate_crab_moves(big_nodes, &big_nodes[input[0]], big_size, 1e7);
  auto t1 = cs::high_resolution_clock::now();

  std::cout
      << "simulated 10 million rounds of crab cups with 1 million cups in "
      << cs::duration_cast<cs::milliseconds>(t1 - t0).count() << " ms\n";
  print_nodes(big_nodes[1].next, 2);
}