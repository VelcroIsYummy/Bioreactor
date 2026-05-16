import streamlit as sl

temprature = "Placeholder"
sl.write(f"""
# Bioreactor Overview

## Bioreactor temprature
Current temprature: {temprature}
""")
sl.line_chart()
