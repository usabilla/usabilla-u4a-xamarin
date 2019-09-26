FROM ubuntu:18.04

# install nuget
RUN apt-get update -y && \
    apt-get install nuget -y --no-install-recommends && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*
