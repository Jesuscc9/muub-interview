// Schema for the "concerts" collection
db.createCollection('concerts', {
  validator: {
    $jsonSchema: {
      bsonType: 'object',
      properties: {
        date: {
          bsonType: 'date',
          description: 'Concert date'
        },
        description: {
          bsonType: 'string',
          description: 'Concert description'
        },
        location: {
          bsonType: 'string',
          description: 'Concert location'
        },
        artists: {
          bsonType: 'array',
          items: {
            bsonType: 'objectId',
            description: 'ID of the artist'
          },
          description: 'List of artist IDs who will participate in the concert'
        },
        createdAt: {
          bsonType: 'date',
          description: 'Created at date'
        }
      }
    }
  }
})

// Schema for the "artists" collection
db.createCollection('artists', {
  validator: {
    $jsonSchema: {
      bsonType: 'object',
      properties: {
        name: {
          bsonType: 'string',
          description: 'Artist name'
        },
        biography: {
          bsonType: 'string',
          description: 'Artist biography'
        },
        followers: {
          bsonType: 'number',
          description: 'Artist followers'
        },
        avatarUrl: {
          bsonType: 'string',
          description: 'Artist avatar url'
        },
        concerts: {
          bsonType: 'array',
          items: {
            bsonType: 'objectId',
            description: 'IDs of the concerts'
          },
          description: 'List of concert IDs who will participate in the artist'
        }
      }
    }
  }
})
