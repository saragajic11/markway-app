# Use Python base image for ARM64 architecture
FROM arm64v8/python

# Set working directory in the container
WORKDIR /app

# Copy requirements.txt and install dependencies
COPY requirements.txt requirements.txt
RUN pip install --no-cache-dir -r requirements.txt
RUN apt-get update \
    && apt-get install -y wkhtmltopdf

# Copy the Flask application files to the container
COPY . .

# Expose the Flask application port (5000)
EXPOSE 9387

# Run the Flask application
CMD ["python", "html_to_pdf.py"]

