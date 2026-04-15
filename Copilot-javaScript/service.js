const express = require('express');
const app = express();
const PORT = 3000;

app.use(express.json());

// Sample data
const products = [
  { id: 1, name: 'Product 1', price: 29.99 },
  { id: 2, name: 'Product 2', price: 39.99 }
];

const customers = [
  { id: 1, name: 'John Doe', email: 'john@example.com' },
  { id: 2, name: 'Jane Smith', email: 'jane@example.com' }
];

// Products routes
app.get('/products', (req, res) => {
  res.json(products);
});

app.get('/products/:id', (req, res) => {
  const product = products.find(p => p.id === parseInt(req.params.id));
  if (!product) return res.status(404).json({ message: 'Product not found' });
  res.json(product);
});

app.post('/products', (req, res) => {
  const product = {
    id: products.length + 1,
    name: req.body.name,
    price: req.body.price
  };
  products.push(product);
  res.status(201).json(product);
});

// Customers routes
app.get('/customers', (req, res) => {
  res.json(customers);
});

app.get('/customers/:id', (req, res) => {
  const customer = customers.find(c => c.id === parseInt(req.params.id));
  if (!customer) return res.status(404).json({ message: 'Customer not found' });
  res.json(customer);
});

app.post('/customers', (req, res) => {
  const customer = {
    id: customers.length + 1,
    name: req.body.name,
    email: req.body.email
  };
  customers.push(customer);
  res.status(201).json(customer);
});

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});