const express = require('express');
const app = express();

app.use(express.json());

// GET endpoint that serves HTML form
app.get('/', (req, res) => {
  res.send(`
    <!DOCTYPE html>
    <html>
    <head>
      <title>API Form</title>
    </head>
    <body>
      <h1>Submit Data</h1>
      <form action="/api/endpoint" method="POST">
        <input type="text" name="data" placeholder="Enter text" required />
        <button type="submit">Submit</button>
      </form>
      <button type="button" id="generateBtn">Generate</button>
      <div id="result"></div>
      <script>
        document.getElementById('generateBtn').addEventListener('click', async () => {
          try {
            const response = await fetch('/generate', {
              method: 'POST',
              headers: {
                'Content-Type': 'application/json'
              }
            });
            const data = await response.json();
            document.getElementById('result').innerHTML = '<pre>' + JSON.stringify(data, null, 2) + '</pre>';
          } catch (error) {
            document.getElementById('result').innerHTML = '<p>Error: ' + error.message + '</p>';
          }
        });
      </script>
    </body>
    </html>
  `);
});

// POST endpoint that accepts JSON payload
app.post('/api/endpoint', (req, res) => {
  try {
    const payload = req.body;
    
    // Process the JSON payload
    console.log('Received payload:', payload);
    
    // Send response
    res.status(200).json({
      success: true,
      message: 'Payload received successfully',
      data: payload
    });
  } catch (error) {
    res.status(400).json({
      success: false,
      message: 'Error processing request',
      error: error.message
    });
  }
});

// Start server
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`);
});
