export const template = {
    "components": [
        {
            "name": "page",
            "properties": [
                {
                    "name": "property1",
                    "type": "text",
                    "value": null,
                    "links": [
                        {
                            "href": "/_kola/property-types/text",
                            "rel": "type"
                        }
                    ]
                },
                {
                    "name": "property2",
                    "type": "text",
                    "value": null,
                    "links": [
                        {
                            "href": "/_kola/property-types/text",
                            "rel": "type"
                        }
                    ]
                },
                {
                    "name": "text",
                    "type": "text",
                    "value": null,
                    "links": [
                        {
                            "href": "/_kola/property-types/text",
                            "rel": "type"
                        }
                    ]
                }
            ],
            "areas": [
                {
                    "name": "header",
                    "components": [
                        {
                            "name": "html-style",
                            "properties": [
                                {
                                    "name": "content",
                                    "type": "multiline-text",
                                    "value": {
                                        "value": "body {\n  font-family: monospace;\n  font-size: 24px;\n}\n\nh1 {\n  color: red;\n}\n\nh2 {\n  color: orange;\n}\n\nh3 {\n  color: blue;\n}\n\nh4 {\n  color: green;\n}\n\ndiv {\nmargin-top: 20px;\n}\n                  ",
                                        "type": "fixed"
                                    },
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/multiline-text",
                                            "rel": "type"
                                        }
                                    ]
                                },
                                {
                                    "name": "media",
                                    "type": "text",
                                    "value": null,
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/text",
                                            "rel": "type"
                                        }
                                    ]
                                },
                                {
                                    "name": "type",
                                    "type": "html-style-type",
                                    "value": {
                                        "value": "text/css",
                                        "type": "fixed"
                                    },
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/html-style-type",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "atom",
                            "path": "/0/0/0",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/0/0",
                                    "rel": "self"
                                }
                            ]
                        }
                    ],
                    "type": "area",
                    "path": "/0/0",
                    "links": [
                        {
                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/0",
                            "rel": "self"
                        }
                    ]
                },
                {
                    "name": "content",
                    "components": [
                        {
                            "name": "div",
                            "properties": [
                                {
                                    "name": "classes",
                                    "type": "text",
                                    "value": null,
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/text",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "components": [
                                {
                                    "name": "text",
                                    "properties": [
                                        {
                                            "name": "text",
                                            "type": "text",
                                            "value": {
                                                "value": "Accept: {{request-headers:Accept}}",
                                                "type": "fixed"
                                            },
                                            "links": [
                                                {
                                                    "href": "/_kola/property-types/text",
                                                    "rel": "type"
                                                }
                                            ]
                                        }
                                    ],
                                    "comment": null,
                                    "type": "atom",
                                    "path": "/0/1/0/0",
                                    "links": [
                                        {
                                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/0/0",
                                            "rel": "self"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "container",
                            "path": "/0/1/0",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/0",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "markdown",
                            "properties": [
                                {
                                    "name": "markdown",
                                    "type": "markdown",
                                    "value": {
                                        "value": "#Hello!!!\n\n##How\n\n###are\n\n####you?\n                  ",
                                        "type": "fixed"
                                    },
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/markdown",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "atom",
                            "path": "/0/1/1",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/1",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "container",
                            "properties": [
                                {
                                    "name": "header-text",
                                    "type": "markdown",
                                    "value": {
                                        "value": "###Header Text",
                                        "type": "fixed"
                                    },
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/markdown",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "areas": [
                                {
                                    "name": "bits",
                                    "components": [
                                        {
                                            "name": "div",
                                            "properties": [
                                                {
                                                    "name": "classes",
                                                    "type": "text",
                                                    "value": null,
                                                    "links": [
                                                        {
                                                            "href": "/_kola/property-types/text",
                                                            "rel": "type"
                                                        }
                                                    ]
                                                }
                                            ],
                                            "components": [
                                                {
                                                    "name": "markdown",
                                                    "properties": [
                                                        {
                                                            "name": "markdown",
                                                            "type": "markdown",
                                                            "value": {
                                                                "value": "*add content here*",
                                                                "type": "fixed"
                                                            },
                                                            "links": [
                                                                {
                                                                    "href": "/_kola/property-types/markdown",
                                                                    "rel": "type"
                                                                }
                                                            ]
                                                        }
                                                    ],
                                                    "comment": null,
                                                    "type": "atom",
                                                    "path": "/0/1/2/0/0/0",
                                                    "links": [
                                                        {
                                                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/2/0/0/0",
                                                            "rel": "self"
                                                        }
                                                    ]
                                                }
                                            ],
                                            "comment": null,
                                            "type": "container",
                                            "path": "/0/1/2/0/0",
                                            "links": [
                                                {
                                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/2/0/0",
                                                    "rel": "self"
                                                }
                                            ]
                                        }
                                    ],
                                    "type": "area",
                                    "path": "/0/1/2/0",
                                    "links": [
                                        {
                                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/2/0",
                                            "rel": "self"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "widget",
                            "path": "/0/1/2",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/2",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "markdown",
                            "properties": [
                                {
                                    "name": "markdown",
                                    "type": "markdown",
                                    "value": {
                                        "value": "<button>I am a button</button>\n\n[I am a link](http://www.linn.co.uk)",
                                        "type": "fixed"
                                    },
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/markdown",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "atom",
                            "path": "/0/1/3",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/3",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "markdown",
                            "properties": [
                                {
                                    "name": "markdown",
                                    "type": "markdown",
                                    "value": {
                                        "contextName": "country-code",
                                        "variants": [
                                            {
                                                "contextValue": "gb",
                                                "isDefault": true,
                                                "value": {
                                                    "value": "Oh I say!",
                                                    "type": "fixed"
                                                }
                                            },
                                            {
                                                "contextValue": "fr",
                                                "isDefault": false,
                                                "value": {
                                                    "value": "Ooh la-la!",
                                                    "type": "fixed"
                                                }
                                            },
                                            {
                                                "contextValue": "ba",
                                                "isDefault": false,
                                                "value": {
                                                    "key": "message1",
                                                    "type": "inherited"
                                                }
                                            },
                                            {
                                                "contextValue": "be",
                                                "isDefault": false,
                                                "value": {
                                                    "contextName": "language-code",
                                                    "variants": [
                                                        {
                                                            "contextValue": "fl",
                                                            "isDefault": true,
                                                            "value": {
                                                                "value": "Belgian flemish",
                                                                "type": "fixed"
                                                            }
                                                        },
                                                        {
                                                            "contextValue": "fr",
                                                            "isDefault": false,
                                                            "value": {
                                                                "value": "Belgian french",
                                                                "type": "fixed"
                                                            }
                                                        }
                                                    ],
                                                    "type": "variable"
                                                }
                                            }
                                        ],
                                        "type": "variable"
                                    },
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/markdown",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "atom",
                            "path": "/0/1/4",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/4",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "text",
                            "properties": [
                                {
                                    "name": "text",
                                    "type": "text",
                                    "value": {
                                        "key": "raw-query",
                                        "type": "inherited"
                                    },
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/text",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "atom",
                            "path": "/0/1/5",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/5",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "text",
                            "properties": [
                                {
                                    "name": "text",
                                    "type": "text",
                                    "value": {
                                        "key": "quiz",
                                        "type": "inherited"
                                    },
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/text",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "atom",
                            "path": "/0/1/6",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/6",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "div",
                            "properties": [
                                {
                                    "name": "classes",
                                    "type": "text",
                                    "value": null,
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/text",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "components": [
                                {
                                    "name": "text",
                                    "properties": [
                                        {
                                            "name": "text",
                                            "type": "text",
                                            "value": {
                                                "value": "{{request-headers}}",
                                                "type": "fixed"
                                            },
                                            "links": [
                                                {
                                                    "href": "/_kola/property-types/text",
                                                    "rel": "type"
                                                }
                                            ]
                                        }
                                    ],
                                    "comment": null,
                                    "type": "atom",
                                    "path": "/0/1/7/0",
                                    "links": [
                                        {
                                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/7/0",
                                            "rel": "self"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "container",
                            "path": "/0/1/7",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/7",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "div",
                            "properties": [
                                {
                                    "name": "classes",
                                    "type": "text",
                                    "value": null,
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/text",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "components": [
                                {
                                    "name": "text",
                                    "properties": [
                                        {
                                            "name": "text",
                                            "type": "text",
                                            "value": {
                                                "value": "{{request-caller-ip}}",
                                                "type": "fixed"
                                            },
                                            "links": [
                                                {
                                                    "href": "/_kola/property-types/text",
                                                    "rel": "type"
                                                }
                                            ]
                                        }
                                    ],
                                    "comment": null,
                                    "type": "atom",
                                    "path": "/0/1/8/0",
                                    "links": [
                                        {
                                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/8/0",
                                            "rel": "self"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "container",
                            "path": "/0/1/8",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/8",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "div",
                            "properties": [
                                {
                                    "name": "classes",
                                    "type": "text",
                                    "value": null,
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/text",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "components": [
                                {
                                    "name": "text",
                                    "properties": [
                                        {
                                            "name": "text",
                                            "type": "text",
                                            "value": {
                                                "key": "message1",
                                                "type": "inherited"
                                            },
                                            "links": [
                                                {
                                                    "href": "/_kola/property-types/text",
                                                    "rel": "type"
                                                }
                                            ]
                                        }
                                    ],
                                    "comment": null,
                                    "type": "atom",
                                    "path": "/0/1/9/0",
                                    "links": [
                                        {
                                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/9/0",
                                            "rel": "self"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "container",
                            "path": "/0/1/9",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/9",
                                    "rel": "self"
                                }
                            ]
                        },
                        {
                            "name": "div",
                            "properties": [
                                {
                                    "name": "classes",
                                    "type": "text",
                                    "value": null,
                                    "links": [
                                        {
                                            "href": "/_kola/property-types/text",
                                            "rel": "type"
                                        }
                                    ]
                                }
                            ],
                            "components": [
                                {
                                    "name": "text",
                                    "properties": [
                                        {
                                            "name": "text",
                                            "type": "text",
                                            "value": {
                                                "key": "message2",
                                                "type": "inherited"
                                            },
                                            "links": [
                                                {
                                                    "href": "/_kola/property-types/text",
                                                    "rel": "type"
                                                }
                                            ]
                                        }
                                    ],
                                    "comment": null,
                                    "type": "atom",
                                    "path": "/0/1/10/0",
                                    "links": [
                                        {
                                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/10/0",
                                            "rel": "self"
                                        }
                                    ]
                                }
                            ],
                            "comment": null,
                            "type": "container",
                            "path": "/0/1/10",
                            "links": [
                                {
                                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1/10",
                                    "rel": "self"
                                }
                            ]
                        }
                    ],
                    "type": "area",
                    "path": "/0/1",
                    "links": [
                        {
                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/1",
                            "rel": "self"
                        }
                    ]
                },
                {
                    "name": "scripts",
                    "components": [],
                    "type": "area",
                    "path": "/0/2",
                    "links": [
                        {
                            "href": "/_kola/templates/components?templatePath=/&componentPath=/0/2",
                            "rel": "self"
                        }
                    ]
                }
            ],
            "comment": null,
            "type": "widget",
            "path": "/0",
            "links": [
                {
                    "href": "/_kola/templates/components?templatePath=/&componentPath=/0",
                    "rel": "self"
                }
            ]
        }
    ],
    "links": [
        {
            "href": "/_kola/templates?templatePath=/",
            "rel": "self"
        },
        {
            "href": "/_kola/templates/amendments?templatePath=/",
            "rel": "amendments"
        },
        {
            "href": "/?preview=y",
            "rel": "preview"
        }
    ]

};