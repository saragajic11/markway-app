from flask import Flask, request, make_response
import pdfkit
from werkzeug.urls import url_unquote as url_quote

app = Flask(__name__)

def generate_pdf_from_html(html_string):
    """
    Generate a PDF from an HTML string.

    :param html_string: HTML string content
    :return: Generated PDF as bytes
    """
    options = {
        'page-size': 'A4',
        'margin-top': '0.75in',
        'margin-right': '0.75in',
        'margin-bottom': '0.75in',
        'margin-left': '0.75in',
    }
    
    pdf = pdfkit.from_string(html_string, False, options=options)
    return pdf

@app.route('/generate-pdf', methods=['POST'])
def generate_pdf():
    """
    Endpoint to generate PDF from HTML string.

    :return: Generated PDF as response
    """
    try:
        html_string = request.json.get('html_string')
        if not html_string:
            return {'error': 'HTML string is required'}, 400
        
        pdf_bytes = generate_pdf_from_html(html_string)
        
        # Create a response with the PDF content
        response = make_response(pdf_bytes)
        response.headers['Content-Type'] = 'application/pdf'
        response.headers['Content-Disposition'] = 'attachment; filename=output.pdf'
        
        print(response)
        print("uradio sam konverziju")

        return response
    
    except Exception as e:
        return {'error': str(e)}, 500

if __name__ == "__main__":
    print("im running")
    app.run(debug=False, host='0.0.0.0', port=9387)
